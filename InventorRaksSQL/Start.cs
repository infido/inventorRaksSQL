using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace InventorRaksSQL
{
    public partial class Start : Form
    {
        public ConnectionDB polaczenie;
        private FbDataAdapter fda;
        private DataSet fds;
        private DataView fDataView;
        private String strQuery;
        private String tabela;
        private Dictionary<string, string> cascheStatus;
        private string kolumna;

        private Int32 memberRow = -1;
        private Int32 memberColumn = -1;
        
        public Start()
        {
            InitializeComponent();
            polaczenie = new ConnectionDB();
            Text = "InventorRaksSQL " + Application.ProductVersion;
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polaczenie.Show();
        }
    }
}
