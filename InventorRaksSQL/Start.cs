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
        private int liczSan = 0;

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
            zaspisZrzutuDoPlikuLog();
            polaczenie.Close();
        }

        private void textBoxInputScaner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (checkIsLogin() && e.KeyChar == Convert.ToChar(Keys.Return))
            {
                zaspisPojedynczegoKoduDoPlikuLog(textBoxInputScaner.Text);
                
                textBoxBufor.Text += textBoxInputScaner.Text + Environment.NewLine;
                textBoxInputScaner.Text = "";

                liczSan += 1;
                licznikSkanow.Text = liczSan.ToString();
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

        private void zaspisPojedynczegoBlednegoKoduDoPlikuLog(string kod, string dodatkowyOpis)
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_error_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine(kod + ";" + textBoxLogin.Text + ";" + DateTime.Now.ToString() + ";" + comboBoxTypRemanentu.Text +";"+dodatkowyOpis);

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

        private void zaspisWszystkichKodowDoPlikuLog(string opisDoLoga)
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_all_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine(opisDoLoga + textBoxLogin.Text + ";" + DateTime.Now.ToString() + ";" + comboBoxTypRemanentu.Text);
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

        private void zaspisZrzutuDoPlikuLog()
        {
            StreamWriter writer = new StreamWriter(Environment.GetEnvironmentVariable("temp") + "\\InventorRaksSQL_zrzut_" + DateTime.Now.ToShortDateString() + ".log", true);
            try
            {
                writer.WriteLine("Początek " + DateTime.Now.ToString() + Environment.NewLine);

                writer.WriteLine("Zrzut >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + Environment.NewLine + textBoxLogin.Text + ";" + DateTime.Now.ToString() + ";" + comboBoxTypRemanentu.Text + Environment.NewLine);
                
                writer.WriteLine("BUFOR START ====================================");
                writer.WriteLine(textBoxBufor.Text);
                writer.WriteLine("BUFOR KONIEC ====================================" + Environment.NewLine);

                writer.WriteLine("HISTORIA START ====================================");
                writer.WriteLine(textBoxHistoriaKodowPelna.Text);
                writer.WriteLine("HISTORIA KONIEC ====================================" + Environment.NewLine);


                writer.WriteLine("NIEUDANE KODY START ====================================");
                writer.WriteLine(textBoxHistoriaNieudanychKodow.Text);
                writer.WriteLine("NIEUDANE KODY KONIEC ====================================" + Environment.NewLine);
                writer.WriteLine("Koniec " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);
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
                //textBoxHistoriaKodowPelna.Text += "tekst " + Environment.NewLine + "tekst " + Environment.NewLine + "tekst " + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Value + Environment.NewLine;
                //textBoxHistoriaNieudanychKodow.Text += "kod " + Environment.NewLine + "kod " + Environment.NewLine + "kod " + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Key + Environment.NewLine;
                foreach (string item in textBoxBufor.Lines)
                    {
                        if (item.Length > 0)
                        {
                            dopiszDoRemanentu(item, ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Key, comboBoxTypRemanentu.ToString(), textBoxLogin.Text);
                        }         
                    }
                //zapis i czyszczenie
                zaspisWszystkichKodowDoPlikuLog("Zapis przy zapisywaniu do remanentu: ");
                textBoxBufor.Text = "";
                buttonZerujLicznik.PerformClick();
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
                zaspisWszystkichKodowDoPlikuLog("Zapis po wklejeniu ze schowka;");
            }
        }

        private void dopiszDoRemanentu(string kodKreskowy, int idRemanentu, string opisRemanetu, string lokalizacja)
        {
            FbCommand cdk;
            FbCommand cdi;
            string sql;
            string errOpis = "";
            int currId = -1;
            decimal pozostalo = 1;  //skanujemy tylko 1 jednocześnie
            int jestRekordow = 0;
            decimal ilStara = 0;
            decimal ilNowa = 0;

            sql = "select count(*) ";
            sql += "from GM_REPOZ join GM_TOWARY on GM_REPOZ.ID_TOWAR=GM_TOWARY.ID ";
            sql+= "WHERE GM_REPOZ.ID_RE=" + idRemanentu +  " AND GM_TOWARY.KOD_KRESKOWY='" + kodKreskowy + "' AND GM_REPOZ.ILOSC_STARA>GM_REPOZ.ILOSC_NOWA ";
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
                sql += "WHERE GM_REPOZ.ID_RE=" + idRemanentu + " AND GM_TOWARY.KOD_KRESKOWY='" + kodKreskowy + "' AND GM_REPOZ.ILOSC_STARA>GM_REPOZ.ILOSC_NOWA ";
                sql += "order by GM_REPOZ.DATA_ZAKUPU DESC";
                cdk = new FbCommand(sql, polaczenie.getConnection());


                try
                {
                    FbDataReader fdk = cdk.ExecuteReader();
                    while (fdk.Read() && pozostalo>0)
                    {
                        currId = (int)fdk["IDPOZ"];
                        ilStara = (decimal)fdk["ILOSC_STARA"];
                        ilNowa = (decimal)fdk["ILOSC_NOWA"];
                        if ((ilStara - ilNowa) >= pozostalo)
                        {
                            cdi = new FbCommand("update GM_REPOZ set ILOSC_NOWA=" + (ilNowa + pozostalo) + " where IDPOZ=" + currId, polaczenie.getConnection());
                            try
                            {
                                cdi.ExecuteNonQuery();
                                textBoxHistoriaKodowPelna.Text += "Kod: " + kodKreskowy + "; Zwiększenie ilości z " + ilNowa + " na " + (ilNowa+pozostalo) + Environment.NewLine;
                            }
                            catch (Exception ec)
                            {
                                MessageBox.Show("Błąd zwiększania na pozycji remanentu dla kk: " + kodKreskowy + "Błąd: " + ec.Message);
                                throw;
                            }
                            pozostalo = 0;
                        }
                        else
                        {
                            cdi = new FbCommand("update GM_REPOZ set ILOSC_NOWA=" + (ilStara - ilNowa) + " where IDPOZ=" + currId, polaczenie.getConnection());
                            try
                            {
                                cdi.ExecuteNonQuery();
                                textBoxHistoriaKodowPelna.Text += "Kod: " + kodKreskowy + "; Zwiększenie ilości w petli z " + ilNowa + " na " + (ilNowa + (ilStara - ilNowa)) + Environment.NewLine;
                            }
                            catch (Exception ec)
                            {
                                MessageBox.Show("Błąd zwiększania na pozycji remanentu dla kk: " + kodKreskowy + ", dla pozycji mniej niż do przypisania, Błąd: " + ec.Message);
                                throw;
                            }
                            pozostalo -= (ilStara - ilNowa);
                        }
                        
                    }

                    if (pozostalo > 0)
                    {
                        errOpis = "W remanancie brak wystarczającej ilosci pozycji do zwiększenia, proszę sprawdzić recznie do jakiej dostawy posicać lub czy nie jest na innym magazynie. Kod:" + kodKreskowy;
                        MessageBox.Show(errOpis);
                        textBoxHistoriaKodowPelna.Text += errOpis + Environment.NewLine;
                        dopiszNieudanyKodDoListyOrazLog(kodKreskowy, idRemanentu, opisRemanetu, lokalizacja, errOpis);
                    }
                }
                catch (FbException ex)
                {
                    errOpis = "Błąd wczytywania listy remanentów: " + ex.Message;
                    textBoxHistoriaKodowPelna.Text += errOpis + Environment.NewLine;
                    MessageBox.Show(errOpis);
                }
            }
            else
            {
                errOpis = "Brak pozycji z wystarczającą ilością dla kodu: " + kodKreskowy;
                textBoxHistoriaKodowPelna.Text += errOpis + Environment.NewLine;
                dopiszNieudanyKodDoListyOrazLog(kodKreskowy, idRemanentu, opisRemanetu, lokalizacja, errOpis);
            }
        }



        private void dopiszNieudanyKodDoListyOrazLog(string kodKreskowy, int idRemanentu, string opisRemanetu, string lokalizacja, string dodatkowyOpisBledu)
        {
            textBoxHistoriaNieudanychKodow.Text += kodKreskowy + Environment.NewLine;
            zaspisPojedynczegoBlednegoKoduDoPlikuLog(kodKreskowy, dodatkowyOpisBledu);
        }

        private void zerowanieRemanentuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length > 0)
            {
                if (MessageBox.Show("Czy jesteż pewien, że należy wyzerować wszystkie pozycje w remanencie: " + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Value,"Pytanie",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (MessageBox.Show("Czy rzeczywiście jesteż pewien, operacja jest nieodwracalna i wszytkie dne zostaną skasowane!", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FbCommand cdi = new FbCommand("update GM_REPOZ set ILOSC_NOWA=0 where ID_RE=" + ((KeyValuePair<int, string>)comboBoxTypRemanentu.SelectedItem).Key, polaczenie.getConnection());
                        bool przerwano = false;
                        try
                        {
                            cdi.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            przerwano = true;
                            MessageBox.Show("Bład i przerwano zerowanie pozycji: " + ex.Message);
                            throw;
                        }

                        if (!przerwano) MessageBox.Show("Pozycje remanentu skasowane!");
                    }
                }
            }
            else
                MessageBox.Show("Nie wprowadzono nazwiska użytkownika","Ostrzeżenie",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void buttonZerujLicznik_Click(object sender, EventArgs e)
        {
            liczSan = 0;
            licznikSkanow.Text = "0";
        }

        private void buttonRaport_Click(object sender, EventArgs e)
        {
            Parametry pr = new Parametry(polaczenie);
            pr.Show();
        }

    }
}
