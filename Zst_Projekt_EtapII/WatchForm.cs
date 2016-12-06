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
    public partial class WatchForm : Form
    {
        public int numberOfIterations;
        public int timeDelay;

        public WatchForm()
        {
            InitializeComponent();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void button_Proceed_Click(object sender, EventArgs e)
        {
            numberOfIterations = Int32.Parse(textBox_numberOfIt.Text);
            timeDelay = Int32.Parse(textBox_timeDelay.Text)*1000;
            Visible = false;
        }
    }
}
