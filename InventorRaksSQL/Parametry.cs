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
    public partial class Parametry : Form
    {
        ConnectionDB polaczenieLo;

        public Parametry(ConnectionDB polaczenie)
        {
            InitializeComponent();
            polaczenieLo = polaczenie;
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Raport_operatorow_" + DateTime.Now.ToLongDateString() + ".xls";

            string sql = "select gm_fs.OPERATOR,gm_fs.DATA_WYSTAWIENIA,gm_fs.NUMER, gm_fs.NAZWA_SPOSOBU_PLATNOSCI, gm_towary.SKROT, COALESCE(gm_towary.SKROT2,'') as SKROT2, ";
            sql += "gm_towary.NAZWA,GM_FSPOZ.ILOSC,GM_FSPOZ.CENA_SPRZEDAZY, GM_FSPOZ.ILOSC * GM_FSPOZ.CENA_SPRZEDAZY as WARTOSC ";
            sql += "from gm_fspoz ";
            sql +=  " join gm_fs on gm_fspoz.id_glowki=gm_fs.id ";
            sql +=  "join gm_towary on gm_fspoz.id_towaru=gm_towary.id ";
            sql += " where gm_fs.data_wystawienia>='" + dateOdDaty.Text.ToString() + "' and gm_fs.data_wystawienia<='" + dateDoDaty.Text.ToString() + "'";
            FbCommand cdk = new FbCommand(sql, polaczenieLo.getConnection());

            StreamWriter writer = new StreamWriter(mydocpath , false);
            try
            {
                writer.WriteLine("OPERATOR;DATA_WYSTAWIENIA;NUMER;SPOSOB_PLATNOSCI;SKROT;SKROT2; NAZWA;ILOSC;CENA_SPRZEDAZY;WARTOSC");
                FbDataReader fdk = cdk.ExecuteReader();
                while (fdk.Read())
                {
                    writer.WriteLine( (string)fdk["OPERATOR"] + ";" +
                                      ((DateTime)fdk["DATA_WYSTAWIENIA"]).ToShortDateString() + ";" +
                                      (string)fdk["NUMER"] + ";" +
                                      (string)fdk["NAZWA_SPOSOBU_PLATNOSCI"] + ";" +
                                      (string)fdk["SKROT"] + ";" +
                                      (string)fdk["SKROT2"] + ";" +
                                      (string)fdk["NAZWA"] + ";" +
                                      (decimal)fdk["ILOSC"] + ";" +
                                      (decimal)fdk["CENA_SPRZEDAZY"] + ";" +
                                      (decimal)fdk["WARTOSC"]);
                }
            }
            catch (FbException ex)
            {
                MessageBox.Show("Błąd wczytywania raportu: " + ex.Message);
            }
            finally
            {
                writer.Close();
            }
            try
            {
                System.Diagnostics.Process.Start(mydocpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd(" + mydocpath + "): " + ex.Message );
                throw;
            }
            
        }

        private void getRaportOperatorow()
        {
            /*
             * Indeks, nazwa, ilosc sprzedana w okresie, cena zakupu netto,cena sprzedaży netto, marża, zysk netto, użytkownik, magazyn
             * wybór użytkownika
             */
        }

        private void bSprzedazWgDostawcow_Click(object sender, EventArgs e)
        {
            /*
             * Magazyn, indeks,Nazwa tow,ilosc sprzedana w zakresie dat, stan w magazynie, stan min, stan max, do zamówienia (nadstan z minusem), dostawca, producent
             * Wskazanie dostawcy lub producenta
             */
        }
    }
}
