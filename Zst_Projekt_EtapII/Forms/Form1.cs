using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SnmpSharpNet;
//snmpsharpnet.com <- tutaj do pobrania ta biblioteka
//Dokumentacja: docs.snmpsharpnet.com/docs-0-9-1/
using System.Timers;
using System.Net;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Zst_Projekt_EtapII
{
    public partial class Form1 : Form
    {
        #region SNMP_Variables
        string _agentsIP;
        int _clientListeningPort;

        int _objectAmmount;
        List<string> _lstOID;
        List<string> _lstObjectName;

        int _tableObjectsAmmount;
        List<string> _lstTableOID;
        List<string> _lstTableName;

        OctetString _community;
        AgentParameters _param;

        string _resultString;
        Oid _oid;
        
        System.Timers.Timer GeneratorsTimer;
        int _numberOfIterations;
        int _watchIterations;
        #endregion

        #region Public Variables
        public int TableObjectAmmount
        {
            get { return _tableObjectsAmmount; }
        }
        public List<string> TableOID
        {
            get { return _lstTableOID; }
        }

        #endregion


        #region Database_Variables
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlDataAdapter;
        private string sqlConnectionString;
        private string sqlQuery;
        #endregion

        public Form1()
        {
            InitializeComponent();

            InitializeLocalParameters();
            InitializeDataBaseComponent();
        }


        #region Another_Methodes
        private void InitializeLocalParameters()
        {
            _agentsIP = null;
            _clientListeningPort = 162;

            _lstObjectName = new List<string>();
            _lstOID = new List<string>();

            _community = new OctetString("public");
            _param = new AgentParameters(_community);
            _param.Version = SnmpVersion.Ver2;
        }

        /*
         * Metoda przypisuje adres IP, gdy tylko wpiszemy go w odpowiednie miejsce.
         */
        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {
            _agentsIP = textBox_IP.Text;
        }

        private void textBox_OID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _oid = new Oid(textBox_OID.Text);
            }
            catch { }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (_watchIterations < _numberOfIterations)
            {
                GetRequest();
                _watchIterations++;
            }  
            else
                GeneratorsTimer.Enabled = false;
        }
        #endregion

        /*
         * //pdu.VbList.Add("1.3.6.1.2.1.1.1.0"); //sysDescr //OID + VALUE
         *  //pdu.VbList.Add("1.3.6.1.2.1.1.2.0"); //sysObjectID
         *  //pdu.VbList.Add("1.3.6.1.2.1.1.3.0"); //sysUpTime
         *  //pdu.VbList.Add("1.3.6.1.2.1.1.4.0"); //sysContact
         *  //pdu.VbList.Add("1.3.6.1.2.1.1.5.0"); //sysName
         */
        #region SNMP_metodes
        public SnmpV2Packet GetRequest(Oid oid)
        {
            IpAddress agent = new IpAddress(_agentsIP);
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.Get);

            //Adding new property to PDU list
            _oid =  new Oid(textBox_OID.Text);
            pdu.VbList.Add(_oid);

            // Make SNMP request
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, _param);

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    string errorMessage = String.Format("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus.ToString(),
                        result.Pdu.ErrorIndex.ToString());
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
                    return null;
                }
                else
                {
                    //DATABASE adding
                    string newOid = result.Pdu.VbList[0].Oid.ToString();
                    string newValue = result.Pdu.VbList[0].Value.ToString();
                    string newType = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString();
                    string newIp = _agentsIP;

                    AddItemToDatabase(newOid, newValue, newType, newIp);

                    return result;
                }
            }
            else
            {
                MessageBox.Show("No response received from SNMP agent.", "Error", MessageBoxButtons.OK);
                return null;
            }
        }
        public SnmpV2Packet GetNextRequest(Oid oid)
        {
            IpAddress agent = new IpAddress(_agentsIP);
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.GetNext);

            //Adding new property to PDU list
            pdu.VbList.Add(oid);

            // Make SNMP request
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, _param);

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    string errorMessage = String.Format("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus.ToString(),
                        result.Pdu.ErrorIndex.ToString());
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
                    return null;
                }
                else
                {
                    // Reply variables are returned in the same order as they were added
                    //  to the VbList

                    //DATABASE adding
                    string newOid = result.Pdu.VbList[0].Oid.ToString();
                    string newValue = result.Pdu.VbList[0].Value.ToString();
                    string newType = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString();
                    string newIp = _agentsIP;
                    _oid = result.Pdu.VbList[0].Oid;
                    AddItemToDatabase(newOid, newValue, newType, newIp);

                    return result;
                }
            }
            else
            {
                MessageBox.Show("No response received from SNMP agent.", "Error",MessageBoxButtons.OK);
                return null;
            }
        }
               
        private void GetRequest()
        {
            GetRequest(_oid);
        }
        private void GetNextRequest()
        {
            GetNextRequest(_oid);
        }
        #endregion

        #region ButtonSNMP_Methodes
        private void button_Get_Click(object sender, EventArgs e)
        {
            if(_agentsIP == null || textBox_OID.Text == null)
                MessageBox.Show("Please, enter the right OID and/or IP address.", "Error", MessageBoxButtons.OK);
            else
                GetRequest();
        }
        private void button_GetNext_Click(object sender, EventArgs e)
        {
            if (textBox_OID.Text == null || _agentsIP == null)
                MessageBox.Show("Please, enter the right OID and/or IP address.", "Error", MessageBoxButtons.OK);
            else
                GetNextRequest();
        }


        private void button_Watch_Click(object sender, EventArgs e)
        {
            if (textBox_OID.Text == null || _agentsIP == null)
                MessageBox.Show("Please, enter the right OID and/or IP address.", "Error", MessageBoxButtons.OK);
            else
            {
                WatchForm wf = new WatchForm();
                wf.ShowDialog();

                if(wf.okClicked)
                {
                    _numberOfIterations = wf.numberOfIterations;
                    int timeDelay = wf.timeDelay;
                    _watchIterations = 0;

                    GeneratorsTimer = new System.Timers.Timer();
                    GeneratorsTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    GeneratorsTimer.Interval = timeDelay;
                    GeneratorsTimer.Enabled = true; 
                }
                wf.Dispose();
            }
        }
        private void button_GetTable_Click(object sender, EventArgs e)
        {
            if ((_agentsIP == null) || (_agentsIP == ""))
            {
                MessageBox.Show("Please, type Address first...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //ukrywam obecny formularz
                this.Visible = false;

                //tworzę specjalne okienko
                TableViewerForm tableViewer = new TableViewerForm(this);
                tableViewer.ShowDialog(this);

                //zapisuje logi do naszej bazy danych

                //po wykonaniu czynności
                tableViewer.Dispose();

                //pokazuje obecny formularz
                this.Visible = true;

                //wyświetlam wyniki
                button_Refresh.PerformClick();
            }
        }      
        #endregion

        #region Database_Methodes
        /*
         * Metoda inicjalizuje wszystkie zmienne niezbędne do poprawnej pracy bazy danych.
         */
        private void InitializeDataBaseComponent()
        {
            //ustawianie connectionString'a - jest to string opisujący gdzie znajduje sie konkretna baza danych
            sqlConnectionString = ConfigurationManager.ConnectionStrings["Zst_Projekt_EtapII.Properties.Settings.ResponsesConnectionString"].ConnectionString;

            //uzupełniam comboBoxa wartościami takimi samymi jak nazwy kolumn
            comboBox_SearchType.Items.Add("OID");
            comboBox_SearchType.Items.Add("Value");
            comboBox_SearchType.Items.Add("Type");
            comboBox_SearchType.Items.Add("IP");

            //uzupełniam comboBoxa zawierającego dozwolone operatory
            comboBox_Search_Operator.Items.Add("<");
            comboBox_Search_Operator.Items.Add("<=");
            comboBox_Search_Operator.Items.Add("=");
            comboBox_Search_Operator.Items.Add(">=");
            comboBox_Search_Operator.Items.Add(">");

            //wyświetlam nasza tabelę
            button_Refresh_Click(this, null);
        }
        /*
         * Metoda pobiera wszystkie dane z bazy danych i wyświetla je w dataGridView
         * - w bazie danych znajduje się tylko jedna tabela MainTable
         */
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            //tworzę polecenie sql zalezne od wyboru użytkownika
            sqlQuery = "SELECT * FROM MainTable";

            //using powoduje, że po wyjściu z klamer obiekty się zamkną samoczynnie
            //dataAdapter samoczynnie otwiera połaczenie, wiec nie trzeba pisac sqlConnection.Open();
            using (sqlConnection = new SqlConnection(sqlConnectionString))
            using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            using (sqlDataAdapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable sqlTable = new DataTable();
                sqlDataAdapter.Fill(sqlTable);

                //pokazywanie tabeli zdarzeń
                dataGridView_Database.DataSource = sqlTable;
            }

            //fokusuje się na ostatnim elemencie
            if (dataGridView_Database.Rows.Count > 0)
            {
                dataGridView_Database.CurrentCell = dataGridView_Database.Rows[dataGridView_Database.Rows.Count - 1].Cells[0];
            }
        }
        /*
         * Metoda usuwa zaznaczony wiersz logów.
         */
        private void button_Remove_Click(object sender, EventArgs e)
        {
            string logIndex;

            if (dataGridView_Database.CurrentCell == null)
                MessageBox.Show("Please, choose the row to remove!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int rowindex = dataGridView_Database.CurrentCell.RowIndex;

                logIndex = dataGridView_Database.Rows[rowindex].Cells[0].Value.ToString();

                //DELETE FROM table_name
                //WHERE some_column = some_value;
                //usuwa zaznaczony wiersz
                sqlQuery = "DELETE FROM MainTable WHERE Id ='" + logIndex + "'";

                using (sqlConnection = new SqlConnection(sqlConnectionString))
                using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    //otwarcie połączenia
                    sqlConnection.Open();

                    //wykonuje instrukcję
                    sqlCommand.ExecuteNonQuery();
                }

                //odświeżam widok tabeli zaprezentowanej w polu
                button_Refresh.PerformClick();
            }
        }
        /*
         * Metoda usuwa całą zawartośc bazy danych i zeruje licznik ID
         */
        private void button_RemoveAll_Click(object sender, EventArgs e)
        {
            //tworzę komendę usuwającą wiersze
            string tmpSqlQueryDeleteRows = "DELETE FROM MainTable; ";

            //tworzę komendę resetującą samozwiększający się licznik id
            string tmpSqlQueryRefreshIDQuery = "DBCC CHECKIDENT('MainTable', RESEED, 0)";

            sqlQuery = tmpSqlQueryDeleteRows + tmpSqlQueryRefreshIDQuery;

            using (sqlConnection = new SqlConnection(sqlConnectionString))
            using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
                //otwarcie połączenia
                sqlConnection.Open();

                //wykonuje instrukcję
                sqlCommand.ExecuteNonQuery();
            }

            //wyświetlanie komunikatu
            MessageBox.Show("Remove_All DONE", "INFORMATION");

            //odświeżam widok tabeli zaprezentowanej w polu
            button_Refresh.PerformClick();
        }
        /*
         * Metoda usuwa całą zawartośc bazy danych i zeruje licznik ID
         */
        private void button_Search_Click(object sender, EventArgs e)
        {
            // TRZEBA TU SPRAWDZIC CZY WYBRALO SIE COS W PARAMETRACH
            if ((comboBox_SearchType.SelectedText != "") || (textBox_Search.SelectedText != ""))
            {
                MessageBox.Show("Please, choose the right item!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //tworzę polecenie sql zalezne od wyboru użytkownika
                //SELECT * FROM eventType1 WHERE LogClientName = 'pop';
                sqlQuery = "SELECT * FROM MainTable WHERE " + comboBox_SearchType.Text
                    + " "+ comboBox_Search_Operator.Text + " '" + textBox_Search.Text + "';";

                //comboBox - nazwa kolumny
                //textBox - szukana wartość (zawsze to będzie string)

                using (sqlConnection = new SqlConnection(sqlConnectionString))
                using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                using (sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable sqlTable = new DataTable();
                    sqlDataAdapter.Fill(sqlTable);

                    //pokazywanie tabeli zdarzeń
                    dataGridView_Database.DataSource = sqlTable;
                }
            }        
        }
        /*
         * Metoda dodaje nowy wpis do bazy danych.
         */
        private void AddItemToDatabase(string oid, string value, string type, string ip)
        {
            sqlQuery = "INSERT INTO MainTable VALUES (@OID, @Value, @Type, @IP)";

            //using powoduje, że po wyjściu z klamer obiekty się zamkną samoczynnie
            //dataAdapter samoczynnie otwiera połaczenie, wiec nie trzeba pisac sqlConnection.Open();
            using (sqlConnection = new SqlConnection(sqlConnectionString))
            using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
              //  sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@OID", oid);
                sqlCommand.Parameters.AddWithValue("@Value", value);
                sqlCommand.Parameters.AddWithValue("@Type", type);
                sqlCommand.Parameters.AddWithValue("@IP", ip);

                //otwieram połączenie
                sqlConnection.Open();

                //wykonuje instrukcję
                sqlCommand.ExecuteNonQuery();
            }

            //aktualizuję wyświetlania
            //button_Refresh.PerformClick();
           
            this.Invoke(new Action(() => { button_Refresh.PerformClick(); }));
        }
        #endregion

        private void dataGridView_Database_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}