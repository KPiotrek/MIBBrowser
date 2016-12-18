using System;
using System.Windows.Forms;

namespace Zst_Projekt_EtapII
{
    public partial class WatchForm : Form
    {
        public int numberOfIterations;
        public int timeDelay;
        public bool okClicked;

        public WatchForm()
        {
            InitializeComponent();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            okClicked = false;
            Visible = false;
        }

        private void button_Proceed_Click(object sender, EventArgs e)
        {
            okClicked = true;

            numberOfIterations = Int32.Parse(textBox_numberOfIt.Text);
            timeDelay = Int32.Parse(textBox_timeDelay.Text)*1000;
            Visible = false;
        }
    }
}
