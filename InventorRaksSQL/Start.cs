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
                
                textBoxBufor.Text += textBoxInputScaner.Text + Environment.NewLine;
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

        private void zaspisPojedynczegoBlednegoKoduDoPlikuLog(string kod)
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_error_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine(kod + ";" + textBoxLogin.Text + ";" + DateTime.Now.ToString() + ";" + comboBoxTypRemanentu.Text);

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
                writer.WriteLine(textBoxBufor.Text);

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
                foreach (string item in textBoxBufor.Lines)
                    {
                        dopiszDoRemanentu(item, ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Key, comboBoxTypRemanentu.ToString(), textBoxLogin.Text);
                    }
            }
        }

        private bool checkIsLogin()
        {
            if (textBoxLogin.Text.Length == 0)
            {
                MessageBox.Show("Nie uzupełniono Nazwiska użytkownika i lokalizacji", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Focus();
                return false;
            }
            else return true;
        }

        private void textBoxHistory_TextChanged(object sender, EventArgs e)
        {
            if (lineCounter != textBoxBufor.Lines.Count())
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

        private void dopiszDoRemanentu(string kodKreskowy, int idRemanentu, string opisRemanetu, string lokalizacja)
        {
            FbCommand cdk;
            string sql;
            int currId = -1;
            int pozostalo = 0;
            int jestRekordow = 0;

            sql = "select count(*) ";
            sql += "from GM_REPOZ join GM_TOWARY on GM_REPOZ.ID_TOWAR=GM_TOWARY.ID ";
            sql+= "WHERE GM_REPOZ.ID_RE=" + idRemanentu +  " AND GM_TOWARY.KOD_KRESKOWY='" + kodKreskowy + "' AND GM_REPOZ.ILOSC_STARA>GM_REPOZ.ILOSC_NOWA";
            sql+= "order by GM_REPOZ.DATA_ZAKUPU DESC";
            cdk = new FbCommand(sql, polaczenie.getConnection());

            try
            {
                jestRekordow = (int)cdk.ExecuteScalar();
            }
            catch (FbException ex)
            {
                MessageBox.Show("Błąd zapytani o ilośc rekordów: " +ex.Message);
                throw;
            }

            if (jestRekordow > 0)
            {
                sql = "select GM_REPOZ.IDPOZ, GM_REPOZ.ID_RE, GM_REPOZ.ID_TOWAR, GM_REPOZ.DATA_ZAKUPU,";
                sql += "GM_REPOZ.ILOSC_NOWA, GM_REPOZ.ILOSC_STARA, GM_REPOZ.CENA_STARA, GM_TOWARY.SKROT, GM_TOWARY.SKROT2, GM_TOWARY.KOD_KRESKOWY ";
                sql += "from GM_REPOZ join GM_TOWARY on GM_REPOZ.ID_TOWAR=GM_TOWARY.ID ";
                sql += "WHERE GM_REPOZ.ID_RE=" + idRemanentu + " AND GM_TOWARY.KOD_KRESKOWY='" + kodKreskowy + "' AND GM_REPOZ.ILOSC_STARA>GM_REPOZ.ILOSC_NOWA";
                sql += "order by GM_REPOZ.DATA_ZAKUPU DESC";
                cdk = new FbCommand(sql, polaczenie.getConnection());
                try
                {
                    FbDataReader fdk = cdk.ExecuteReader();
                    while (fdk.Read() && pozostalo>0)
                    {
                        currId = (int)fdk["IDPOZ"];
                        // sprawdzenei czy moze być
                    }
                }
                catch (FbException ex)
                {
                    MessageBox.Show("Błąd wczytywania listy remanentów: " + ex.Message);
                }
            }
            else
            {
                dopiszNieudanyKodDoListyOrazLog(kodKreskowy, idRemanentu, opisRemanetu, lokalizacja);
            }
        }



        private void dopiszNieudanyKodDoListyOrazLog(string kodKreskowy, int idRemanentu, string opisRemanetu, string lokalizacja)
        {
            textBoxHistoriaNieudanychKodow.Text += kodKreskowy;
            zaspisPojedynczegoBlednegoKoduDoPlikuLog(kodKreskowy);
        }

    }
}
