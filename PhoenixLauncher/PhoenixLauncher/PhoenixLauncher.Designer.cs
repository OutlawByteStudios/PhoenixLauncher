namespace PhoenixLauncher
{
    partial class PhoenixLauncher
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoenixLauncher));
            this.panel = new System.Windows.Forms.Panel();
            this.Headline = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.menu = new System.Windows.Forms.Panel();
            this.buttonLogs = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.configPanel = new System.Windows.Forms.Panel();
            this.groupBoxPathConfig = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.buttonSearchPath = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.menu.SuspendLayout();
            this.configPanel.SuspendLayout();
            this.groupBoxPathConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkOrange;
            this.panel.Controls.Add(this.Headline);
            this.panel.Controls.Add(this.progressBar);
            this.panel.Controls.Add(this.buttonClose);
            this.panel.Controls.Add(this.buttonMenu);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 60);
            this.panel.TabIndex = 0;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Headline.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headline.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Headline.Location = new System.Drawing.Point(12, 5);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(211, 34);
            this.Headline.TabIndex = 2;
            this.Headline.Text = "Phoenix Launcher";
            this.Headline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Headline_MouseDown);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 49);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(800, 11);
            this.progressBar.TabIndex = 3;
            this.progressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressBar_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonClose.Location = new System.Drawing.Point(742, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(55, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonMenu.Location = new System.Drawing.Point(553, 3);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(183, 40);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Console.Location = new System.Drawing.Point(12, 66);
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            this.Console.Size = new System.Drawing.Size(776, 372);
            this.Console.TabIndex = 1;
            this.Console.Text = "";
            // 
            // menu
            // 
            this.menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menu.BackColor = System.Drawing.Color.DarkOrange;
            this.menu.Controls.Add(this.buttonLogin);
            this.menu.Controls.Add(this.buttonLogs);
            this.menu.Controls.Add(this.buttonUpdate);
            this.menu.Controls.Add(this.buttonCheck);
            this.menu.Controls.Add(this.buttonConfig);
            this.menu.Location = new System.Drawing.Point(553, 60);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(247, 390);
            this.menu.TabIndex = 0;
            this.menu.Visible = false;
            this.menu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menu_MouseDown);
            // 
            // buttonLogs
            // 
            this.buttonLogs.FlatAppearance.BorderSize = 0;
            this.buttonLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogs.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogs.Location = new System.Drawing.Point(3, 132);
            this.buttonLogs.Name = "buttonLogs";
            this.buttonLogs.Size = new System.Drawing.Size(241, 37);
            this.buttonLogs.TabIndex = 5;
            this.buttonLogs.Text = "Logs";
            this.buttonLogs.UseVisualStyleBackColor = true;
            this.buttonLogs.Click += new System.EventHandler(this.buttonLogs_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLogin.Location = new System.Drawing.Point(3, 353);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(241, 34);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUpdate.Location = new System.Drawing.Point(3, 89);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(241, 37);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            this.buttonCheck.FlatAppearance.BorderSize = 0;
            this.buttonCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheck.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheck.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCheck.Location = new System.Drawing.Point(3, 46);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(241, 37);
            this.buttonCheck.TabIndex = 2;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            // 
            // buttonConfig
            // 
            this.buttonConfig.FlatAppearance.BorderSize = 0;
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonConfig.Location = new System.Drawing.Point(3, 3);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(241, 37);
            this.buttonConfig.TabIndex = 1;
            this.buttonConfig.Text = "Config";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // configPanel
            // 
            this.configPanel.BackColor = System.Drawing.Color.DarkOrange;
            this.configPanel.Controls.Add(this.groupBoxPathConfig);
            this.configPanel.Location = new System.Drawing.Point(3, 60);
            this.configPanel.Name = "configPanel";
            this.configPanel.Size = new System.Drawing.Size(547, 390);
            this.configPanel.TabIndex = 2;
            this.configPanel.Visible = false;
            this.configPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.configPanel_MouseDown);
            // 
            // groupBoxPathConfig
            // 
            this.groupBoxPathConfig.Controls.Add(this.buttonSearchPath);
            this.groupBoxPathConfig.Controls.Add(this.path);
            this.groupBoxPathConfig.Controls.Add(this.label1);
            this.groupBoxPathConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxPathConfig.Location = new System.Drawing.Point(3, 7);
            this.groupBoxPathConfig.Name = "groupBoxPathConfig";
            this.groupBoxPathConfig.Size = new System.Drawing.Size(541, 73);
            this.groupBoxPathConfig.TabIndex = 0;
            this.groupBoxPathConfig.TabStop = false;
            this.groupBoxPathConfig.Text = "Path Configuration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to the mb_warband.exe";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(10, 39);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(449, 20);
            this.path.TabIndex = 1;
            // 
            // buttonSearchPath
            // 
            this.buttonSearchPath.Location = new System.Drawing.Point(465, 39);
            this.buttonSearchPath.Name = "buttonSearchPath";
            this.buttonSearchPath.Size = new System.Drawing.Size(70, 20);
            this.buttonSearchPath.TabIndex = 2;
            this.buttonSearchPath.Text = ". . .";
            this.buttonSearchPath.UseVisualStyleBackColor = true;
            // 
            // PhoenixLauncher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.configPanel);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.Console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhoenixLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoenixLauncher";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PhoenixLauncher_MouseDown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.menu.ResumeLayout(false);
            this.configPanel.ResumeLayout(false);
            this.groupBoxPathConfig.ResumeLayout(false);
            this.groupBoxPathConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonLogs;
        public System.Windows.Forms.RichTextBox Console;
        public System.Windows.Forms.Label Headline;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel configPanel;
        private System.Windows.Forms.GroupBox groupBoxPathConfig;
        private System.Windows.Forms.Button buttonSearchPath;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label1;
    }
}

