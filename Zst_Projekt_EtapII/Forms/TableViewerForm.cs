using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Zst_Projekt_EtapII
{
    public partial class TableViewerForm : Form
    {
        Form1 _mainForm;
        Oid _oid;


        public TableViewerForm(Form1 mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }


        private void button_Table_Back_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void button_Table_GetTableOID_Click(object sender, EventArgs e)
        {
            if (textBox_Table_OID.Text == "")
            {
                MessageBox.Show("Please, type OID first...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //odczytuje OID
                _oid = new Oid(textBox_Table_OID.Text);


                //wyłącz przycisk do momentu pojawienia się wyników
                button_Table_GetTableOID.Enabled = false;

                //wywołanie metody GetTable
                GetTable(_oid);
            } 
        }


        private void GetTable(Oid oid)
        {
            SnmpV2Packet localResult = new SnmpV2Packet();
            
            //table[n] wskazuje kolumny
            //table[n][m] wskazuje konkretne komórki
            List<List<String>> table = new List<List<String>>();
            List<string> columnOID = new List<string>();

            // This is the table OID supplied on the command line
            Oid startOid = oid;
            // Each table OID is followed by .1 for the entry OID. Add it to the table OID
            // Add Entry OID to the end of the table OID
            startOid.Add(1);

            // Current OID will keep track of the last retrieved OID and be used as 
            //  indication that we have reached end of table
            Oid currentOid = (Oid)startOid.Clone();
            Oid prevOid = null;

            // Keep looping through results until end of table
            // startOid.IsRootOf(curOid)
            // Compares the passed object identifier against self to determine if self is the root of the passed object. 
            // If the passed object is in the same root tree as self then a true value is returned.
            // Otherwise a false value is returned from the object. 
            while (true)
            {
                //make GetNext
                localResult = _mainForm.GetNextRequest(currentOid);

                //set prev before changing current
                prevOid = currentOid;
                uint[] prevChildOids = Oid.GetChildIdentifiers(startOid, prevOid);

                //set OID result to currentOid
                currentOid = localResult.Pdu.VbList[0].Oid;

                // Make sure we are dealing with an OID that is part of the table
                if (startOid.IsRootOf(currentOid))
                {
                    //get every childOid start from startOID to currentOID
                    // if startOid = .1.1 and currentOid = .1.1.2.1 result will be [0] = 2 [1] = 1
                    uint[] currentChildOids = Oid.GetChildIdentifiers(startOid, currentOid);

                    //first column
                    if((prevOid == startOid))
                    {
                        table.Add(new List<string>());
                        Oid columnOid = (Oid)startOid.Clone();
                        columnOid.Add(currentChildOids[0]);
                        columnOID.Add(columnOid.ToString());
                    }
                        

                    //next columns
                    if (currentChildOids != null && prevChildOids != null)
                    {
                        //the first element is always name of column (new parameter in table)
                        if ((currentChildOids[0] > prevChildOids[0]))
                        {
                            //it means, currentOid is showing another column (parameter)
                            //adding another column!
                            table.Add(new List<string>());
                            Oid columnOid = (Oid)startOid.Clone();
                            columnOid.Add(currentChildOids[0]);
                            columnOID.Add(columnOid.ToString());
                        }
                    }
                    
                    //saving the values
                    table[table.Count-1].Add(localResult.Pdu.VbList[0].Value.ToString());
                }
                else
                {
                    // We've reached the end of the table. No point continuing the loop
                    //wychodzi z pętli tylko wtedy, gdy wyszlismy poza korzeń czyli długość curOid jest taka sama jak start i nie sa równe
                    break;
                }

            }//end of while

            /*
             * startOid - początkowe .1.0
             * prevOid - Oid z poprzedniego wywołania (służy do patrzenia, czy jesteśmy jeszcze w tej samej kolumnie czy już w nastepnej
             * currentOid - otrzymane OID z metody GetNext
             * 
             * curOid musi zawierać całe startOid i być dłuższe aby while działał
             * 
             */

            ShowTable(columnOID, table);
        }
        private void ShowTable(List<string> columnOID, List<List<String>> table)
        {
            DataTable myTable = new DataTable();
            DataColumn dtColumn;
            DataRow myDataRow;

            if (table.Count == 0)
            {
                MessageBox.Show("No results returned.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                for (int i = 0; i < columnOID.Count; i++)
                {
                    dtColumn = new DataColumn();
                    dtColumn.DataType = System.Type.GetType("System.String");
                    dtColumn.ColumnName = columnOID[i];
                    myTable.Columns.Add(dtColumn);
                }

                for (int w = 0; w < table[0].Count; w++)
                {
                    myDataRow = myTable.NewRow();

                    //uzupełniam cały wiersz
                    for (int n = 0; n < table.Count; n++)
                        myDataRow[myTable.Columns[n]] = table[n][w];

                    myTable.Rows.Add(myDataRow);
                }      

                //wyświetlanie tabeli
                dataGridView_TABLE.DataSource = myTable;

                //wyłączenie sortowania
                foreach (DataGridViewColumn column in dataGridView_TABLE.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            //włacz przycisk po wykonanych czynnościach
            button_Table_GetTableOID.Enabled = true;
        }
    }
}
