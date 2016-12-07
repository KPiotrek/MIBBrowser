using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            for (int i = 0; i < _mainForm.TableObjectAmmount; i++)
            {
                comboBox_TableName.Items.Add(_mainForm.TableName[i]);
                comboBox_TableOID.Items.Add(_mainForm.TableOID[i]);
            }
        }

        private void button_Table_GetTable_Click(object sender, EventArgs e)
        {
            //oczytuje nazwe
            string name = comboBox_TableName.Text;

            //wyszukuje OID
            for (int i = 0; i < _mainForm.TableObjectAmmount; i++)
                if (name == _mainForm.TableName[i])
                {
                    _oid = new Oid(_mainForm.TableOID[i]);
                }

            //wywołanie metody GetTable
            GetTable(_oid);
        }

        private void button_Table_GetTableOID_Click(object sender, EventArgs e)
        {
            //odczytuje OID
            _oid = new Oid(comboBox_TableOID.Text);

            //wywołanie metody GetTable
            GetTable(_oid);
        }

        private void GetTable(Oid oid)
        {
            SnmpV2Packet localResult = new SnmpV2Packet();
            
            //table[n] wskazuje kolumny
            //table[n][m] wskazuje konkretne komórki
            List<List<String>> table = new List<List<String>>();

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
                        table.Add(new List<string>());

                    //next columns
                    if (currentChildOids != null && prevChildOids != null)
                    {
                        //the first element is always name of column (new parameter in table)
                        if ((currentChildOids[0] > prevChildOids[0]))
                        {
                            //it means, currentOid is showing another column (parameter)
                            //adding another column!
                            table.Add(new List<string>());
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

            }


            /*
             * startOid - początkowe .1.0
             * prevOid - Oid z poprzedniego wywołania (służy do patrzenia, czy jesteśmy jeszcze w tej samej kolumnie czy już w nastepnej
             * currentOid - otrzymane OID z metody GetNext
             * 
             * curOid musi zawierać całe startOid i być dłuższe aby while działał
             * 
             */
            Console.ReadLine();
        }
    }
}
