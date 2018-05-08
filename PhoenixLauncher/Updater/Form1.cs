using PhoenixLauncher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        private HTTPRequest phoenixClient;
        public Form1()
        {
            InitializeComponent();
            this.phoenixClient = new HTTPRequest();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            

            int Try = 5;
            int counter = 0;

            console.AppendText("starting");
            while (counter <= Try)
            {
                try {
                    console.AppendText("Trying to shutdown PhoenixLauncher");
                    Process[] proc = Process.GetProcessesByName("PhoenixLauncher");
                    proc[0].Kill();
                }
                catch (Exception)
                {
                    break;
                }
                Thread.Sleep(500);
                counter++;
            }
            console.AppendText("PhoenixLauncher shutdown");
            counter = 0;

            while ( counter <= Try && File.Exists("PhoenixLauncher.exe") )
            {
                console.AppendText("Trying to delete PhoenixLauncher");
                File.Delete("PhoenixLauncher.exe");
                Thread.Sleep(500);
                counter++;
            }
            console.AppendText("Deleted PhoenixLauncher");
            counter = 0;


            counter = 0;

            Thread.Sleep(1000);

            Task.Run(() => this.getLauncher());

        }
        public async Task getLauncher()
        {
            await this.phoenixClient.download("https://api.bridgetroll.de/PhoenixLauncher/public/v1/launcher/download", "PhoenixLauncher.exe", false);
            console.AppendText("Trying to start PhoenixLauncher");
            Process.Start("PhoenixLauncher.exe");
            Process.GetCurrentProcess().Kill();
            Thread.Sleep(1000);
        }
    }
}
