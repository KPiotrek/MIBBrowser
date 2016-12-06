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
        string resultString;
        int watchIterations;
        System.Timers.Timer GeneratorsTimer = new System.Timers.Timer();
        List<string> lstOID = new List<string>();
        List<string> lstObjectName = new List<string>();
        int objectAmmount;
        string agentsIP = "127.0.0.1";
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

            InitializeDataBaseComponent();
        }

        #region SNMP_Methodes
        private void button_Get_Click(object sender, EventArgs e)
        {

            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress(agentsIP);

            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.Get);
            //pdu.VbList.Add("1.3.6.1.2.1.1.1.0"); //sysDescr //OID + VALUE
            //pdu.VbList.Add("1.3.6.1.2.1.1.2.0"); //sysObjectID
            //pdu.VbList.Add("1.3.6.1.2.1.1.3.0"); //sysUpTime
            //pdu.VbList.Add("1.3.6.1.2.1.1.4.0"); //sysContact
            //pdu.VbList.Add("1.3.6.1.2.1.1.5.0"); //sysName

            string oid = whatShouldIAdd("Adding new property to PDU list");
            pdu.VbList.Add(oid);

            // Make SNMP request
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus,
                        result.Pdu.ErrorIndex);
                }
                else
                {
                    // Reply variables are returned in the same order as they were added
                    //  to the VbList
                    resultString = String.Format("({0}) ({1}): {2}",
                        result.Pdu.VbList[0].Oid.ToString(),
                        SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString(),
                        result.Pdu.VbList[0].Value.ToString());
                    MessageBox.Show(resultString);

                    //DATABASE adding
                    string newName = cbObjects.Text;
                    string newOid = result.Pdu.VbList[0].Oid.ToString();
                    string newValue = result.Pdu.VbList[0].Value.ToString();
                    string newType = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString();
                    string newIp = agentsIP;

                    AddItemToDatabase(newName, newOid, newValue, newType, newIp);
                }
            }
        }

        private void button_GetNext_Click(object sender, EventArgs e)
        {
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress("127.0.0.1");

            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.GetNext);
            string oid = whatShouldIAdd("Adding new property to PDU list");
            pdu.VbList.Add(oid);

            // Make SNMP request
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);

            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus,
                        result.Pdu.ErrorIndex);
                }
                else
                {
                    // Reply variables are returned in the same order as they were added
                    //  to the VbList
                    resultString = String.Format("({0}) ({1}): {2}",
                      result.Pdu.VbList[0].Oid.ToString(),
                      SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString(),
                      result.Pdu.VbList[0].Value.ToString());
                    MessageBox.Show(resultString);

                    //DATABASE adding
                    string newName = cbObjects.Text;
                    string newOid = result.Pdu.VbList[0].Oid.ToString();
                    string newValue = result.Pdu.VbList[0].Value.ToString();
                    string newType = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString();
                    string newIp = agentsIP;

                    AddItemToDatabase(newName, newOid, newValue, newType, newIp);
                }
            }

            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            } 
            
        }

        private void button_Watch_Click(object sender, EventArgs e)
        {
            watchIterations = 0; ;
            GeneratorsTimer.Enabled = true;
            GeneratorsTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            GeneratorsTimer.Interval = 5000;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            OctetString community = new OctetString("public");

            // Define agent parameters class
            AgentParameters param = new AgentParameters(community);
            // Set SNMP version to 1 (or 2)
            param.Version = SnmpVersion.Ver2;
            // Construct the agent address object
            // IpAddress class is easy to use here because
            //  it will try to resolve constructor parameter if it doesn't
            //  parse to an IP address
            IpAddress agent = new IpAddress("127.0.0.1");
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.Get);
            string oid = whatShouldIAdd("Adding new property to PDU list");
            pdu.VbList.Add(oid);
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);
            
            // If result is null then agent didn't reply or we couldn't parse the reply.
            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by 
                // the Agent - see SnmpConstants for error definitions
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request
                    Console.WriteLine("Error in SNMP reply. Error {0} index {1}",
                        result.Pdu.ErrorStatus,
                        result.Pdu.ErrorIndex);
                }
                else
                {
                    //Komentarz zeby sprawdzic githuba
                    for (int i = 0; i < pdu.VbList.Count; i++)
                    {
                        resultString = String.Format("(0}) ({1}): {2}",
                         result.Pdu.VbList[0].Oid.ToString(),
                         SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString(),
                         result.Pdu.VbList[0].Value.ToString());
                        MessageBox.Show(resultString);
                        watchIterations = watchIterations +1;
                        if (watchIterations > 5)
                        GeneratorsTimer.Enabled = false;
                        //DATABASE adding
                        string newName = cbObjects.Text;
                        string newOid = result.Pdu.VbList[0].Oid.ToString();
                        string newValue = result.Pdu.VbList[0].Value.ToString();
                        string newType = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type).ToString();
                        string newIp = agentsIP;

                        AddItemToDatabase(newName, newOid, newValue, newType, newIp);
                    }

                }
            }

            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }

        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = tbFilepath.Text;
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(ofd.FileName);
                objectAmmount = Int32.Parse(xDoc.SelectSingleNode("MIB/Data/objectAmmount").InnerText);
               

                for (int i = 0; i < objectAmmount; i++)
                {
                    string path = string.Format("MIB/Data/pair{0}/OID", i);
                    string value = xDoc.SelectSingleNode(path).InnerText;

                    lstOID.Add(value);

                }
                for (int i = 0; i < objectAmmount; ++i)
                {
                    string path = String.Format("MIB/Data/pair{0}/objectName", i);
                    string value = xDoc.SelectSingleNode(path).InnerText;
                    cbObjects.Items.Add(value);
                    lstObjectName.Add(value);
                }
                string MIBname = tbFilepath.Text.Split(new[] { "MIB" }, StringSplitOptions.None)[1];
                char[] MyChar = { '.', 'x', 'm', 'l'};
                MIBname = MIBname.TrimEnd(MyChar);
                
                string showString = "MIB has been successfully loaded!" + Environment.NewLine + "MIB name: " + MIBname + Environment.NewLine + "Ammount of objects: " + objectAmmount;
                MessageBox.Show(showString);
            }
            catch
            {
                MessageBox.Show("No such file or directory");

            }
        }

        private string whatShouldIAdd(string oid)
        {
           
            for (int i = 0; i < objectAmmount; ++i)
                if (cbObjects.Text == lstObjectName[i])
                {
                    oid = lstOID[i];
                }
            return oid;

        }
        #endregion

        #region Database_Methodes



        #endregion
        /*
         * Metoda inicjalizuje wszystkie zmienne niezbędne do poprawnej pracy bazy danych.
         */
        private void InitializeDataBaseComponent()
        {
            //ustawianie connectionString'a - jest to string opisujący gdzie znajduje sie konkretna baza danych
            sqlConnectionString = ConfigurationManager.ConnectionStrings["Zst_Projekt_EtapII.Properties.Settings.ResponsesConnectionString"].ConnectionString;

            //czyścimy baze danych
            button_RemoveAll.PerformClick();

            //uzupełniam comboBoxa wartościami takimi samymi jak nazwy kolumn
            comboBox_SearchType.Items.Add("Name");
            comboBox_SearchType.Items.Add("OID");
            comboBox_SearchType.Items.Add("Value");
            comboBox_SearchType.Items.Add("Type");
            comboBox_SearchType.Items.Add("IP");

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
                sqlQuery = "SELECT * FROM MainTable WHERE " + comboBox_SearchType.SelectedText
                    + " = '" + textBox_Search.Text + "';";

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
        private void AddItemToDatabase(string name, string oid, string value, string type, string ip)
        {
            sqlQuery = "INSERT INTO MainTable VALUES (@Name, @OID, @Value, @Type, @IP)";

            //using powoduje, że po wyjściu z klamer obiekty się zamkną samoczynnie
            //dataAdapter samoczynnie otwiera połaczenie, wiec nie trzeba pisac sqlConnection.Open();
            using (sqlConnection = new SqlConnection(sqlConnectionString))
            using (sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Name", name);
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
            button_Refresh.PerformClick();
        }
    }
}