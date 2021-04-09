using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace station_app
{
    public partial class RozkladJazdyForm : Form
    {
        List<Kurs> kursy = new List<Kurs>();
        EkranGlownyForm ekranGlowny;
        DataAccess db = new DataAccess();

        public RozkladJazdyForm(EkranGlownyForm ekran)
        {
            InitializeComponent();
            ekranGlowny = ekran;     
            //ZaładujRozkladJazdy();
        }

        private void ZaladujDane(List<Kurs> kursyDoZaladowania)
        {
            aktualnyRozkladDataGridView.DataSource = kursyDoZaladowania;
            aktualnyRozkladDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            aktualnyRozkladDataGridView.DefaultCellStyle.NullValue = "<brak>";
            aktualnyRozkladDataGridView.Columns[1].DefaultCellStyle.Format = "dd MMMM yyyy";
            aktualnyRozkladDataGridView.Columns[4].DefaultCellStyle.Format = "HH:mm";

            aktualnyRozkladDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            aktualnyRozkladDataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            aktualnyRozkladDataGridView.DefaultCellStyle.Font = new Font("Tahoma", 10);

            List<string> header_texts = new List<string>() {"ID KURSU", "DATA", "STACJA POCZĄTKOWA", "STACJA KOŃCOWA",
                "GODZINA ODJAZDU", "PERON", "OPÓŹNIENIE", "UWAGI", "FK ID RELACJI"};
            for (int i = 0; i < aktualnyRozkladDataGridView.Columns.Count; i++)
            {
                aktualnyRozkladDataGridView.Columns[i].HeaderText = header_texts[i];
            }

            kryteriumComboBox.Items.Clear();
            foreach (DataGridViewColumn column in aktualnyRozkladDataGridView.Columns)
            {
                kryteriumComboBox.Items.Add(column.HeaderText);
            }
        }

        void ZaładujRozkladJazdy()
        {
            try
            {
                string table = "kursy";
                string order = "to_date(to_char(data, 'YYYYMMDD') || to_char(godzina_odjazdu, 'HH24MI'), 'YYYYMMDDHH24MI') ASC";
                kursy = db.GetAllFromTable(table, order, new Kurs());
                ZaladujDane(kursy);
            }
            catch
            {
                new ErrorForm("Nie można pobrać danych! Sprawdź połączenie z bazą danych.").Show();
            }
        }
        private void zaladujDaneButton_Click(object sender, EventArgs e)
        {
            ZaładujRozkladJazdy();
        }

        private void szukajButton_Click(object sender, EventArgs e)
        {
            try
            {
                string table = "kursy";
                string filteringValue = szukajTextBox.Text;
                //string filteringCriterium = kryteriumComboBox.SelectedItem.ToString();
                string filteringCriterium = kryteriumComboBox.Text;
                string order = "to_date(to_char(data, 'YYYYMMDD') || to_char(godzina_odjazdu, 'HH24MI'), 'YYYYMMDDHH24MI') ASC";

                kursy = db.GetSpecificFromTable(table, filteringCriterium, filteringValue, order, new Kurs());
                ZaladujDane(kursy);
            }
            catch
            {
                new ErrorForm("Utracono połączenie z bazą danych lub wprowadzono niewłaściwą wartość kolumny wyszukiwania!").Show();
            }
        }

        private void dodajPolaczenieButton_Click(object sender, EventArgs e)
        {
            NowePolaczenieForm nowePolaczenie = new NowePolaczenieForm(this);
            nowePolaczenie.Show();
            this.Hide();
        }

        private void edytujPolaczenieButton_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>();
            for (int i = 0; i < aktualnyRozkladDataGridView.SelectedRows[0].Cells.Count; i++)
            {
                if (aktualnyRozkladDataGridView.SelectedRows[0].Cells[i].Value != null)
                {
                    parameters.Add(aktualnyRozkladDataGridView.SelectedRows[0].Cells[i].Value.ToString());
                }
                else
                {
                    parameters.Add("");
                }
            }

            EdytujPolaczenieForm edytujPolaczenie = new EdytujPolaczenieForm(this, parameters);
            edytujPolaczenie.Show();
            this.Hide();
        }

        private void usunPolaczenieButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in aktualnyRozkladDataGridView.SelectedRows)
                {
                    db.UsunPolaczenie(row.Cells[0].Value.ToString());
                }
                aktualnyRozkladDataGridView.ClearSelection();
                ZaładujRozkladJazdy();
            }
            catch
            {
                new ErrorForm("Niepoprawnie zaznaczono dane do usunięcia!").Show();
            }
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ekranGlowny.Show();
        }

    }
}
