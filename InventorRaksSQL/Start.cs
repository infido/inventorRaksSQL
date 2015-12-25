using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;

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
        private Dictionary<int, string> listTypRemanenetu;
        private string kolumna;

        private Int32 memberRow = -1;
        private Int32 memberColumn = -1;

        private Int32 lineCounter = 0;
        
        public Start()
        {
            InitializeComponent();
            polaczenie = new ConnectionDB();
            Text = "InventorRaksSQL " + Application.ProductVersion;

            setDictonary();
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            polaczenie.Show();
        }

        private void setDictonary()
        {
            listTypRemanenetu = new Dictionary<int, string>();
            FbCommand cdk = new FbCommand("SELECT GM_RE.ID, CASE GM_RE.TYP WHEN 0 THEN 'Remanent ' ELSE 'Remanenet Częściowy ' END || GM_RE.NUMER || ' z dnia: ' || GM_RE.DATA_WYSTAWIENIA || ' dla magazynu: ' || GM_MAGAZYNY.NAZWA || ' Sygnatura:' || COALESCE(GM_RE.SYGNATURA,'')  as NUMER from GM_RE join GM_MAGAZYNY on GM_RE.MAGNUM=GM_MAGAZYNY.ID where GM_RE.BLOKADA=0", polaczenie.getConnection());
            try
            {
                FbDataReader fdk = cdk.ExecuteReader();
                while (fdk.Read())
                {
                    listTypRemanenetu.Add((int)fdk["ID"], (string)fdk["NUMER"]);
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Błąd wczytywania listy remanentów: " + ex.Message);
            }

            comboBoxTypRemanentu.DataSource = new BindingSource(listTypRemanenetu, null);
            comboBoxTypRemanentu.DisplayMember = "Value";
            comboBoxTypRemanentu.ValueMember = "Key";
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            polaczenie.Close();
        }

        private void textBoxInputScaner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkIsLogin() && e.KeyChar == Convert.ToChar(Keys.Return))
            {
                zaspisPojedynczegoKoduDoPlikuLog(textBoxInputScaner.Text);
                
                textBoxHistory.Text += textBoxInputScaner.Text + Environment.NewLine;
                textBoxInputScaner.Text = "";
            }
        }

        private void zaspisPojedynczegoKoduDoPlikuLog(string kod)
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_poj_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine(kod + ";" + textBoxLogin.Text + ";" + DateTime.Now.ToString()+";"+comboBoxTypRemanentu.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        private void zaspisWszystkichKodowDoPlikuLog()
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_all_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine("Zapis po wklejeniu ze schowka;" + textBoxLogin.Text + ";" + DateTime.Now.ToString() + ";" + comboBoxTypRemanentu.Text);
                writer.WriteLine(textBoxHistory.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                writer.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkIsLogin())
            {
            textBoxHistoriaKodowPelna.Text += "tekst " + Environment.NewLine + "tekst " + Environment.NewLine + "tekst " + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Value + Environment.NewLine;
            textBoxHistoriaNieudanychKodow.Text += "kod " + Environment.NewLine + "kod " + Environment.NewLine + "kod " + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Key + Environment.NewLine;
            }
        }

        private bool checkIsLogin()
        {
            if (textBoxLogin.Text.Length == 0)
            {
                MessageBox.Show("Nie uzupełniono loginu użytkownika", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Focus();
                return false;
            }
            else return true;
        }

        private void textBoxHistory_TextChanged(object sender, EventArgs e)
        {
            if (lineCounter != textBoxHistory.Lines.Count())
            {
                //MessageBox.Show("LN" + textBoxHistory.Lines.Count() +";" + textBoxHistory.Lines.GetValue(textBoxHistory.Lines.Count()-2).ToString());
            }
        }

        private void textBoxHistory_KeyDown(object sender, KeyEventArgs e)
        {
            bool ctrlV = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
            bool shiftIns = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;

            if (ctrlV || shiftIns)
            {
                zaspisWszystkichKodowDoPlikuLog();
            }
        }

    }
}
