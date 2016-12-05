using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnmpSharpNet;
//snmpsharpnet.com <- tutaj do pobrania ta biblioteka
//Dokumentacja: docs.snmpsharpnet.com/docs-0-9-1/
using System.Timers;
using System.Net;
using System.Xml;

namespace Zst_Projekt_EtapII
{
    public partial class Form1 : Form
    {
        string resultString;
        int watchIterations;
        System.Timers.Timer GeneratorsTimer = new System.Timers.Timer();
        List<string> lstOID = new List<string>();
        List<string> lstObjectName = new List<string>();
        int objectAmmount;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnGet_Click(object sender, EventArgs e)
        {

            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress("127.0.0.1");

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
                   
                }


            }
        }

        private void btnGetNext_Click(object sender, EventArgs e)
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
                }
            }

            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            } 
            
        }

        private void btnWatch_Click(object sender, EventArgs e)
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
                    }

                }
            }

            else
            {
                Console.WriteLine("No response received from SNMP agent.");
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
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
                
                string showString = "MIB has been successfully loaded!" + Environment.NewLine + "MIB name: " + MIBname + Environment.NewLine + "Ammount of objects: 4e" + objectAmmount;
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
    }
}