using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhoenixLauncher
{
    public partial class PhoenixLauncher : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private RoutineController routineController;

        public PhoenixLauncher()
        {
            InitializeComponent();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (menu.Visible)
            {
                menu.Visible = false;
                configPanel.Visible = false;
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
            if (configPanel.Visible)
            {
                buttonConfig.BackColor = Color.DarkOrange;
                configPanel.Visible = false;
            }
            else
            {
                buttonConfig.BackColor = Color.Orange;
                configPanel.Visible = true;
                path.Text = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH);
            }
        }

        private void PhoenixLauncher_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void progressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void configPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void menu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Headline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonSearchPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            var tryPath = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH) != null ? ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH) : "C:\\";

            openFileDialog1.InitialDirectory = tryPath;
            openFileDialog1.Filter = "Warband Executeable (*.exe)|mb_warband.exe";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ConfigurationService.write(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH, Path.GetDirectoryName(openFileDialog1.FileName).Replace('\\','/'));
                path.Text = ConfigurationService.get(Config.Launcher.APP_CONFIG_EXECUTEABLE_PATH);
                Logger tmp = new Logger(Console);
                tmp.success("New path @" + Path.GetDirectoryName(openFileDialog1.FileName).Replace('\\', '/'));
                tmp = null;
            }
        }

        private void PhoenixLauncher_Shown(object sender, EventArgs e)
        {
            this.routineController = new RoutineController(this);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
             this.routineController.fileCheck();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.routineController.download();
        }
    }
}
