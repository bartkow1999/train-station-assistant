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
    public partial class FormularzeForm : Form
    {
        EkranGlownyForm ekranGlowny;
        DataAccess db = new DataAccess();
        string aktualnaRelacja;

        public FormularzeForm(EkranGlownyForm ekran)
        {
            InitializeComponent();
            ekranGlowny = ekran;

            List<string> relacje = new List<string>() {"Petenci", "Asystenci", "Typy_pomocy", "Rodzaje_pociagow", "Przewoznicy", "Zestawienia",
                "Relacje", "Stacje", "Trasy", "Kursy", "Pomoce"};
            
            kryteriumComboBox.Items.Clear();
            foreach (string element in relacje)
            {
                zaladujDaneComboBox.Items.Add(element);
            }
        }

        private void ZaladujDane()
        {
            try
            {
                string table_name = zaladujDaneComboBox.Text;
                string order = "1";

                switch (table_name)
                {
                    case "Petenci":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Petent());
                        break;
                    case "Asystenci":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Asystent());
                        break;
                    case "Typy_pomocy":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Typ_pomocy());
                        break;
                    case "Rodzaje_pociagow":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Rodzaj_Pociagu());
                        break;
                    case "Przewoznicy":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Przewoznik());
                        break;
                    case "Zestawienia":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Zestawienie());
                        break;
                    case "Relacje":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Relacja());
                        break;
                    case "Stacje":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Stacja());
                        break;
                    case "Trasy":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Trasa());
                        break;
                    case "Kursy":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Kurs());
                        break;
                    case "Pomoce":
                        formularzDataGridView.DataSource = db.GetAllFromTable(table_name, order, new Pomoc());
                        break;
                }

                formularzDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                formularzDataGridView.DefaultCellStyle.NullValue = "<brak>";

                formularzDataGridView.DefaultCellStyle.ForeColor = Color.Black;
                formularzDataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                formularzDataGridView.DefaultCellStyle.Font = new Font("Tahoma", 10);

                kryteriumComboBox.Items.Clear();
                foreach (DataGridViewColumn column in formularzDataGridView.Columns)
                {
                    kryteriumComboBox.Items.Add(column.HeaderText);
                }

                aktualnaRelacja = table_name;
            }
            catch
            {
                new ErrorForm("Nie można pobrać danych! Sprawdź połączenie z bazą danych.").Show();
            }
        }
        private void zaladujDaneButton_Click(object sender, EventArgs e)
        {
            ZaladujDane();
        }

        private void dodajElementButton_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if (formularzDataGridView.Columns.Count > i)
                {
                    parameters.Add(formularzDataGridView.Columns[i].Name);
                }
                else
                {
                    parameters.Add("");
                }
            }

            NowyFormularzForm nowyFormularz = new NowyFormularzForm(this, aktualnaRelacja, parameters);
            nowyFormularz.Show();
            this.Hide();
        }
        private void edytujElementButton_Click(object sender, EventArgs e)
        {
            List<string> parameters_L = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if (formularzDataGridView.Columns.Count > i)
                {
                    parameters_L.Add(formularzDataGridView.Columns[i].Name);
                }
                else
                {
                    parameters_L.Add("");
                }
            }

            List<string> parameters_P = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                if (formularzDataGridView.Columns.Count > i)
                {
                    if (formularzDataGridView.SelectedRows[0].Cells[i].Value != null)
                    {
                        parameters_P.Add(formularzDataGridView.SelectedRows[0].Cells[i].Value.ToString());
                    }
                    else
                    {
                        parameters_P.Add("");
                    }
                }
                else
                {
                    parameters_P.Add("");
                }
            }

            EdytujFormularzForm edytujFormularz = new EdytujFormularzForm(this, aktualnaRelacja, parameters_L, parameters_P);
            edytujFormularz.Show();
            this.Hide();
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ekranGlowny.Show();
        }

        private void usunElementButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in formularzDataGridView.SelectedRows)
                {
                    switch (aktualnaRelacja)
                    {
                        case "Petenci":
                            db.DeleteRecord(aktualnaRelacja, "ID_petenta", row.Cells[0].Value.ToString());
                            break;
                        case "Asystenci":
                            db.DeleteRecord(aktualnaRelacja, "ID_asystenta", row.Cells[0].Value.ToString());
                            break;
                        case "Typy_pomocy":
                            db.DeleteRecord(aktualnaRelacja, "ID_typu_pomocy", row.Cells[0].Value.ToString());
                            break;
                        case "Rodzaje_pociagow":
                            db.DeleteRecord(aktualnaRelacja, "ID_rodzaju_pociagu", row.Cells[0].Value.ToString());
                            break;
                        case "Przewoznicy":
                            db.DeleteRecord(aktualnaRelacja, "ID_przewoznika", row.Cells[0].Value.ToString());
                            break;
                        case "Zestawienia":
                            db.DeleteRecord(aktualnaRelacja, "ID_zestawienia", row.Cells[0].Value.ToString());
                            break;
                        case "Relacje":
                            db.DeleteRecord(aktualnaRelacja, "ID_relacji", row.Cells[0].Value.ToString());
                            break;
                        case "Stacje":
                            db.DeleteRecord(aktualnaRelacja, "ID_stacji", row.Cells[0].Value.ToString());
                            break;
                        case "Trasy":
                            db.DeleteRecord(aktualnaRelacja, "ID_trasy", row.Cells[0].Value.ToString());
                            break;
                        case "Kursy":
                            db.DeleteRecord(aktualnaRelacja, "ID_kursu", row.Cells[0].Value.ToString());
                            break;
                        case "Pomoce":
                            db.DeleteRecord(aktualnaRelacja, "ID_pomocy", row.Cells[0].Value.ToString());
                            break;
                    }
                }

                formularzDataGridView.ClearSelection();
                ZaladujDane();
            }
            catch
            {
                new ErrorForm("Niepoprawnie zaznaczono dane do usunięcia!").Show();
            }
        }
    }
}
