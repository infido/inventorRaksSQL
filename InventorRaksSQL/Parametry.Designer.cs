namespace InventorRaksSQL
{
    partial class Parametry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parametry));
            this.dateOdDaty = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDoDaty = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.bSprzedazWgDostawcow = new System.Windows.Forms.Button();
            this.bSprzedazWgUzytkownikow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateOdDaty
            // 
            this.dateOdDaty.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOdDaty.Location = new System.Drawing.Point(72, 15);
            this.dateOdDaty.Name = "dateOdDaty";
            this.dateOdDaty.Size = new System.Drawing.Size(97, 20);
            this.dateOdDaty.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Od daty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do daty";
            // 
            // dateDoDaty
            // 
            this.dateDoDaty.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDoDaty.Location = new System.Drawing.Point(72, 41);
            this.dateDoDaty.Name = "dateDoDaty";
            this.dateDoDaty.Size = new System.Drawing.Size(97, 20);
            this.dateDoDaty.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 115);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(166, 26);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "Raport operatorów";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnuluj.Location = new System.Drawing.Point(12, 211);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(166, 26);
            this.buttonAnuluj.TabIndex = 5;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // bSprzedazWgDostawcow
            // 
            this.bSprzedazWgDostawcow.Location = new System.Drawing.Point(12, 147);
            this.bSprzedazWgDostawcow.Name = "bSprzedazWgDostawcow";
            this.bSprzedazWgDostawcow.Size = new System.Drawing.Size(166, 26);
            this.bSprzedazWgDostawcow.TabIndex = 6;
            this.bSprzedazWgDostawcow.Text = "Sprzedaż wg dostawców";
            this.bSprzedazWgDostawcow.UseVisualStyleBackColor = true;
            this.bSprzedazWgDostawcow.Click += new System.EventHandler(this.bSprzedazWgDostawcow_Click);
            // 
            // bSprzedazWgUzytkownikow
            // 
            this.bSprzedazWgUzytkownikow.Location = new System.Drawing.Point(12, 179);
            this.bSprzedazWgUzytkownikow.Name = "bSprzedazWgUzytkownikow";
            this.bSprzedazWgUzytkownikow.Size = new System.Drawing.Size(166, 26);
            this.bSprzedazWgUzytkownikow.TabIndex = 7;
            this.bSprzedazWgUzytkownikow.Text = "Sprzedaż wg użytkowników";
            this.bSprzedazWgUzytkownikow.UseVisualStyleBackColor = true;
            // 
            // Parametry
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAnuluj;
            this.ClientSize = new System.Drawing.Size(246, 243);
            this.Controls.Add(this.bSprzedazWgUzytkownikow);
            this.Controls.Add(this.bSprzedazWgDostawcow);
            this.Controls.Add(this.buttonAnuluj);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDoDaty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateOdDaty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parametry";
            this.Text = "Parametry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateOdDaty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDoDaty;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Button bSprzedazWgDostawcow;
        private System.Windows.Forms.Button bSprzedazWgUzytkownikow;
    }
}