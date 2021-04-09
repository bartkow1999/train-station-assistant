using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace station_app
{
    public partial class HarmonogramPomocyForm : Form
    {
        List<PomoceView> pomoce = new List<PomoceView>();
        EkranGlownyForm ekranGlowny;
        DataAccess db = new DataAccess();

        public HarmonogramPomocyForm(EkranGlownyForm ekran)
        {
            InitializeComponent();
            ekranGlowny = ekran;
            ZaładujPomoce();
        }

        private void ZaladujDane(List<PomoceView> pomoceDoZaladowania)
        {
            aktualnePomoceDataGridView.DataSource = pomoceDoZaladowania;
            aktualnePomoceDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            aktualnePomoceDataGridView.DefaultCellStyle.NullValue = "<brak>";
            aktualnePomoceDataGridView.Columns[1].DefaultCellStyle.Format = "dd MMMM yyyy";
            aktualnePomoceDataGridView.Columns[2].DefaultCellStyle.Format = "HH:mm";

            aktualnePomoceDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            aktualnePomoceDataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            aktualnePomoceDataGridView.DefaultCellStyle.Font = new Font("Tahoma", 10);

            List<string> header_texts = new List<string>() {"ID_POMOCY", "DATA", "GODZINA",
                "KURS", "OPIS", "IMIE", "NAZWISKO", "TELEFON", "MAIL", "UWAGI", "ASYSTENT", "NAZWISKO2" };
            for (int i = 0; i < aktualnePomoceDataGridView.Columns.Count; i++)
            {
                aktualnePomoceDataGridView.Columns[i].HeaderText = header_texts[i];
            }

            kryteriumComboBox.Items.Clear();

            foreach (DataGridViewColumn column in aktualnePomoceDataGridView.Columns)
            {
                kryteriumComboBox.Items.Add(column.HeaderText);
            }
        }

        void ZaładujPomoce()
        {
            string table = "pomoce_view";
            string order = "to_date(to_char(data_zgloszenia, 'YYYYMMDD') || to_char(godzina_zgloszenia, 'HH24MI'), 'YYYYMMDDHH24MI') ASC";
            try
            {
                pomoce = db.GetAllFromTableHelpsView(table, order);
                ZaladujDane(pomoce);
            }
            catch
            {
                new ErrorForm("Nie można pobrać danych! Sprawdź połączenie z bazą danych.").Show();
            }
        }

        private void zaladujDaneButton_Click(object sender, EventArgs e)
        {
            ZaładujPomoce();
        }

        private void szukajButton_Click(object sender, EventArgs e)
        {
            try
            {
                string table = "pomoce_view";
                string filteringValue = szukajTextBox.Text;
                //string filteringCriterium = kryteriumComboBox.SelectedItem.ToString();
                string filteringCriterium = kryteriumComboBox.Text;
                string order = "to_date(to_char(data_zgloszenia, 'YYYYMMDD') || to_char(godzina_zgloszenia, 'HH24MI'), 'YYYYMMDDHH24MI') ASC";

                pomoce = db.GetSpecificFromTableHelps(table, filteringCriterium, filteringValue, order);
                ZaladujDane(pomoce);
            }
            catch
            {
                new ErrorForm("Utracono połączenie z bazą danych lub wprowadzono niewłaściwą wartość kolumny wyszukiwania!").Show();
            }
        }

        private void dodajPolaczenieButton_Click(object sender, EventArgs e)
        {
            NowaPomoc nowaPomoc = new NowaPomoc(this);
            nowaPomoc.Show();
            this.Hide();
        }

        private void edytujPolaczenieButton_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>();
            for (int i = 0; i < aktualnePomoceDataGridView.SelectedRows[0].Cells.Count; i++)
            {
                if (aktualnePomoceDataGridView.SelectedRows[0].Cells[i].Value != null)
                {
                    parameters.Add(aktualnePomoceDataGridView.SelectedRows[0].Cells[i].Value.ToString());
                }
                else
                {
                    parameters.Add("");
                }
            }

            EdytujPomoc edytujPolaczenie = new EdytujPomoc(this, parameters);
            edytujPolaczenie.Show();
            this.Hide();
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ekranGlowny.Show();
        }

        private void usunPomocButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in aktualnePomoceDataGridView.SelectedRows)
                {
                    db.UsunPomoc(row.Cells[0].Value.ToString());
                }
                aktualnePomoceDataGridView.ClearSelection();
                ZaładujPomoce();
            }
            catch
            {
                new ErrorForm("Niepoprawnie zaznaczono dane do usunięcia!").Show();
            }
        }
    }
}
