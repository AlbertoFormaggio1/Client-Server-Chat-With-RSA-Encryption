namespace PrimaProva
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.keysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateRandomKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lBChat = new System.Windows.Forms.ListBox();
            this.lBCrypted = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.tbServerPort);
            this.groupBox1.Controls.Add(this.tbServerIP);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SERVER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Yellow;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(393, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbServerPort
            // 
            this.tbServerPort.BackColor = System.Drawing.Color.Ivory;
            this.tbServerPort.Location = new System.Drawing.Point(222, 47);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(143, 20);
            this.tbServerPort.TabIndex = 1;
            // 
            // tbServerIP
            // 
            this.tbServerIP.BackColor = System.Drawing.Color.Ivory;
            this.tbServerIP.Location = new System.Drawing.Point(44, 47);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(131, 20);
            this.tbServerIP.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.tbClientPort);
            this.groupBox2.Controls.Add(this.tbClientIP);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CLIENT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Yellow;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnConnect.FlatAppearance.BorderSize = 2;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(393, 39);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(102, 32);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbClientPort
            // 
            this.tbClientPort.BackColor = System.Drawing.Color.Ivory;
            this.tbClientPort.Location = new System.Drawing.Point(222, 46);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(143, 20);
            this.tbClientPort.TabIndex = 4;
            this.tbClientPort.Text = "\r\n";
            // 
            // tbClientIP
            // 
            this.tbClientIP.BackColor = System.Drawing.Color.Ivory;
            this.tbClientIP.Location = new System.Drawing.Point(44, 46);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(131, 20);
            this.tbClientIP.TabIndex = 3;
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.Ivory;
            this.tbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.Location = new System.Drawing.Point(12, 545);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(354, 29);
            this.tbMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Yellow;
            this.btnSend.Enabled = false;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnSend.FlatAppearance.BorderSize = 3;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(399, 546);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(108, 32);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keysToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // keysToolStripMenuItem
            // 
            this.keysToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.keysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateNewKeysToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.keysToolStripMenuItem.Name = "keysToolStripMenuItem";
            this.keysToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.keysToolStripMenuItem.Text = "File";
            // 
            // generateNewKeysToolStripMenuItem
            // 
            this.generateNewKeysToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.generateNewKeysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateRandomKeysToolStripMenuItem,
            this.insertKeyToolStripMenuItem});
            this.generateNewKeysToolStripMenuItem.Enabled = false;
            this.generateNewKeysToolStripMenuItem.Name = "generateNewKeysToolStripMenuItem";
            this.generateNewKeysToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generateNewKeysToolStripMenuItem.Text = "Keys";
            // 
            // generateRandomKeysToolStripMenuItem
            // 
            this.generateRandomKeysToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.generateRandomKeysToolStripMenuItem.Name = "generateRandomKeysToolStripMenuItem";
            this.generateRandomKeysToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.generateRandomKeysToolStripMenuItem.Text = "Generate Random keys";
            this.generateRandomKeysToolStripMenuItem.Click += new System.EventHandler(this.generateRandomKeysToolStripMenuItem_Click);
            // 
            // insertKeyToolStripMenuItem
            // 
            this.insertKeyToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.insertKeyToolStripMenuItem.Name = "insertKeyToolStripMenuItem";
            this.insertKeyToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.insertKeyToolStripMenuItem.Text = "Insert key";
            this.insertKeyToolStripMenuItem.Click += new System.EventHandler(this.insertKeyToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaAccountToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.accountToolStripMenuItem.Enabled = false;
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // creaAccountToolStripMenuItem
            // 
            this.creaAccountToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.creaAccountToolStripMenuItem.Name = "creaAccountToolStripMenuItem";
            this.creaAccountToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.creaAccountToolStripMenuItem.Text = "Crea Account";
            this.creaAccountToolStripMenuItem.Click += new System.EventHandler(this.creaAccountToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.BackColor = System.Drawing.Color.PapayaWhip;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // lBChat
            // 
            this.lBChat.BackColor = System.Drawing.Color.Ivory;
            this.lBChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBChat.FormattingEnabled = true;
            this.lBChat.ItemHeight = 16;
            this.lBChat.Location = new System.Drawing.Point(12, 280);
            this.lBChat.Name = "lBChat";
            this.lBChat.Size = new System.Drawing.Size(354, 244);
            this.lBChat.TabIndex = 6;
            // 
            // lBCrypted
            // 
            this.lBCrypted.BackColor = System.Drawing.Color.Ivory;
            this.lBCrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBCrypted.FormattingEnabled = true;
            this.lBCrypted.ItemHeight = 16;
            this.lBCrypted.Location = new System.Drawing.Point(372, 280);
            this.lBCrypted.Name = "lBCrypted";
            this.lBCrypted.Size = new System.Drawing.Size(170, 244);
            this.lBCrypted.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Chat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Crypted Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(554, 605);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lBCrypted);
            this.Controls.Add(this.lBChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.TextBox tbClientIP;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem keysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateRandomKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListBox lBChat;
        private System.Windows.Forms.ListBox lBCrypted;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
    }
}

