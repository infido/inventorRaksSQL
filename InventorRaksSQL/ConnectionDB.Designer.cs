namespace InventorRaksSQL
{
    partial class ConnectionDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDB));
            this.label1 = new System.Windows.Forms.Label();
            this.Zapisz = new System.Windows.Forms.Button();
            this.tUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.instalacjaSieciowa = new System.Windows.Forms.RadioButton();
            this.instalacjaLokalna = new System.Windows.Forms.RadioButton();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.tServer = new System.Windows.Forms.TextBox();
            this.tPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tPort = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Testuj = new System.Windows.Forms.Button();
            this.outtext = new System.Windows.Forms.RichTextBox();
            this.bRozlacz = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bNewFDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Użytkownik*";
            // 
            // Zapisz
            // 
            this.Zapisz.Location = new System.Drawing.Point(258, 397);
            this.Zapisz.Name = "Zapisz";
            this.Zapisz.Size = new System.Drawing.Size(80, 32);
            this.Zapisz.TabIndex = 1;
            this.Zapisz.Text = "Z&apisz";
            this.Zapisz.UseVisualStyleBackColor = true;
            this.Zapisz.Click += new System.EventHandler(this.Zapisz_Click);
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(84, 61);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(100, 20);
            this.tUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(517, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "*UWAGA! Ustawienie połaczenie do bazy danych, pozostawienie pustego pola oznacza " +
                "wartośc domyślną !";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Adres serwera*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ścieżka*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.instalacjaSieciowa);
            this.groupBox1.Controls.Add(this.instalacjaLokalna);
            this.groupBox1.Location = new System.Drawing.Point(15, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rodzaj instalacji";
            // 
            // instalacjaSieciowa
            // 
            this.instalacjaSieciowa.AutoSize = true;
            this.instalacjaSieciowa.Checked = true;
            this.instalacjaSieciowa.Location = new System.Drawing.Point(116, 19);
            this.instalacjaSieciowa.Name = "instalacjaSieciowa";
            this.instalacjaSieciowa.Size = new System.Drawing.Size(68, 17);
            this.instalacjaSieciowa.TabIndex = 1;
            this.instalacjaSieciowa.TabStop = true;
            this.instalacjaSieciowa.Text = "Sieciowa";
            this.instalacjaSieciowa.UseVisualStyleBackColor = true;
            this.instalacjaSieciowa.CheckedChanged += new System.EventHandler(this.instalacjaSieciowa_CheckedChanged);
            // 
            // instalacjaLokalna
            // 
            this.instalacjaLokalna.AutoSize = true;
            this.instalacjaLokalna.Location = new System.Drawing.Point(17, 19);
            this.instalacjaLokalna.Name = "instalacjaLokalna";
            this.instalacjaLokalna.Size = new System.Drawing.Size(63, 17);
            this.instalacjaLokalna.TabIndex = 0;
            this.instalacjaLokalna.Text = "Lokalna";
            this.instalacjaLokalna.UseVisualStyleBackColor = true;
            this.instalacjaLokalna.CheckedChanged += new System.EventHandler(this.instalacjaLokalna_CheckedChanged);
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(250, 61);
            this.tPassword.Name = "tPassword";
            this.tPassword.Size = new System.Drawing.Size(100, 20);
            this.tPassword.TabIndex = 8;
            // 
            // tServer
            // 
            this.tServer.Location = new System.Drawing.Point(301, 109);
            this.tServer.Name = "tServer";
            this.tServer.Size = new System.Drawing.Size(217, 20);
            this.tServer.TabIndex = 9;
            // 
            // tPath
            // 
            this.tPath.Location = new System.Drawing.Point(63, 155);
            this.tPath.Name = "tPath";
            this.tPath.Size = new System.Drawing.Size(340, 20);
            this.tPath.TabIndex = 10;
            this.tPath.DoubleClick += new System.EventHandler(this.tPath_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Port*";
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(441, 155);
            this.tPort.Name = "tPort";
            this.tPort.Size = new System.Drawing.Size(77, 20);
            this.tPort.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Testuj
            // 
            this.Testuj.Location = new System.Drawing.Point(15, 397);
            this.Testuj.Name = "Testuj";
            this.Testuj.Size = new System.Drawing.Size(75, 32);
            this.Testuj.TabIndex = 14;
            this.Testuj.Text = "&Połącz";
            this.Testuj.UseVisualStyleBackColor = true;
            this.Testuj.Click += new System.EventHandler(this.Testuj_Click);
            // 
            // outtext
            // 
            this.outtext.BackColor = System.Drawing.Color.Azure;
            this.outtext.Location = new System.Drawing.Point(15, 181);
            this.outtext.Name = "outtext";
            this.outtext.ReadOnly = true;
            this.outtext.Size = new System.Drawing.Size(503, 176);
            this.outtext.TabIndex = 15;
            this.outtext.Text = "";
            // 
            // bRozlacz
            // 
            this.bRozlacz.Location = new System.Drawing.Point(177, 397);
            this.bRozlacz.Name = "bRozlacz";
            this.bRozlacz.Size = new System.Drawing.Size(75, 32);
            this.bRozlacz.TabIndex = 16;
            this.bRozlacz.Text = "&Rozłącz";
            this.bRozlacz.UseVisualStyleBackColor = true;
            this.bRozlacz.Click += new System.EventHandler(this.bRozlacz_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(456, 331);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(62, 26);
            this.bClear.TabIndex = 17;
            this.bClear.Text = "Wyczyść";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bNewFDB
            // 
            this.bNewFDB.Location = new System.Drawing.Point(96, 397);
            this.bNewFDB.Name = "bNewFDB";
            this.bNewFDB.Size = new System.Drawing.Size(75, 32);
            this.bNewFDB.TabIndex = 18;
            this.bNewFDB.Text = "&Twórz bazę";
            this.bNewFDB.UseVisualStyleBackColor = true;
            this.bNewFDB.Click += new System.EventHandler(this.bNewFDB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 19;
            this.button1.Text = "&Zamknij";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem,
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zapiszKonfiguracjęDoPlikuToolStripMenuItem
            // 
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem.Name = "zapiszKonfiguracjęDoPlikuToolStripMenuItem";
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem.Text = "Zapisz  konfigurację do pliku";
            this.zapiszKonfiguracjęDoPlikuToolStripMenuItem.Click += new System.EventHandler(this.zapiszKonfiguracjęDoPlikuToolStripMenuItem_Click);
            // 
            // otwórzKonfiguracjęZPlikuToolStripMenuItem
            // 
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem.Name = "otwórzKonfiguracjęZPlikuToolStripMenuItem";
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem.Text = "Otwórz konfigurację z pliku";
            this.otwórzKonfiguracjęZPlikuToolStripMenuItem.Click += new System.EventHandler(this.otwórzKonfiguracjęZPlikuToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"xml files|*.xml|Wszystkie pliki|*.*\"";
            this.openFileDialog1.Title = "Otwórz plik ustawień";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "xml files|*.xml|Wszystkie pliki|*.*";
            // 
            // ConnectionDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(536, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bNewFDB);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bRozlacz);
            this.Controls.Add(this.outtext);
            this.Controls.Add(this.Testuj);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.tServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tUser);
            this.Controls.Add(this.Zapisz);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConnectionDB";
            this.Text = "Ustawienie połaczenia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Zapisz;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tServer;
        private System.Windows.Forms.RadioButton instalacjaSieciowa;
        private System.Windows.Forms.RadioButton instalacjaLokalna;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.TextBox tPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button Testuj;
        private System.Windows.Forms.RichTextBox outtext;
        private System.Windows.Forms.Button bRozlacz;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bNewFDB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszKonfiguracjęDoPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzKonfiguracjęZPlikuToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}