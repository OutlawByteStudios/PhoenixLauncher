using System;
using System.Windows.Forms;

namespace PhoenixLauncher
{
    public partial class PhoenixLauncher : Form
    {
        public PhoenixLauncher()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (menu.Visible)
            {
                menu.Visible = false;
            }
            else
            {
                menu.Visible = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            if (Console.Visible)
            {
                Console.Visible = false;
            }
            else
            {
                Console.Visible = true;
            }
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
