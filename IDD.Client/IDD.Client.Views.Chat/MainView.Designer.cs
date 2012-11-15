namespace IDD.Client
{
    partial class MainView
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
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verbindenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbUser = new System.Windows.Forms.ListBox();
            this.lbChat = new System.Windows.Forms.ListBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(590, 438);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Senden";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verbindenToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // verbindenToolStripMenuItem
            // 
            this.verbindenToolStripMenuItem.Name = "verbindenToolStripMenuItem";
            this.verbindenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.verbindenToolStripMenuItem.Text = "Verbinden...";
            this.verbindenToolStripMenuItem.Click += new System.EventHandler(this.verbindenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // lbUser
            // 
            this.lbUser.FormattingEnabled = true;
            this.lbUser.Location = new System.Drawing.Point(590, 27);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(120, 407);
            this.lbUser.TabIndex = 2;
            // 
            // lbChat
            // 
            this.lbChat.FormattingEnabled = true;
            this.lbChat.Location = new System.Drawing.Point(0, 27);
            this.lbChat.Name = "lbChat";
            this.lbChat.Size = new System.Drawing.Size(584, 407);
            this.lbChat.TabIndex = 3;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(12, 440);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(572, 20);
            this.tbText.TabIndex = 4;
            this.tbText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbText_KeyDown);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 468);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.lbChat);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(731, 507);
            this.MinimumSize = new System.Drawing.Size(731, 507);
            this.Name = "MainView";
            this.Text = "Testchat";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verbindenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ListBox lbUser;
        private System.Windows.Forms.ListBox lbChat;
        private System.Windows.Forms.TextBox tbText;
    }
}

