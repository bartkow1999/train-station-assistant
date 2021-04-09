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
    public partial class EdytujFormularzForm : Form
    {
        FormularzeForm formularze;
        DataAccess db = new DataAccess();
        string aktualna_relacja;

        public EdytujFormularzForm(FormularzeForm form, string relacja, List<string> parameters_L, List<string> parameters_P)
        {
            InitializeComponent();
            formularze = form;
            aktualna_relacja = relacja;

            LoadElements(parameters_L, parameters_P);
        }

        private void LoadElements(List<string> parameters_L, List<string> parameters_P)
        {
            formL0TextBox.Text = parameters_L[0];
            formL1TextBox.Text = parameters_L[1];
            formL2TextBox.Text = parameters_L[2];
            formL3TextBox.Text = parameters_L[3];
            formL4TextBox.Text = parameters_L[4];
            formL5TextBox.Text = parameters_L[5];
            formL6TextBox.Text = parameters_L[6];
            formL7TextBox.Text = parameters_L[7];
            formL8TextBox.Text = parameters_L[8];
            formL9TextBox.Text = parameters_L[9];

            formP0TextBox.Text = parameters_P[0];
            formP1TextBox.Text = parameters_P[1];
            formP2TextBox.Text = parameters_P[2];
            formP3TextBox.Text = parameters_P[3];
            formP4TextBox.Text = parameters_P[4];
            formP5TextBox.Text = parameters_P[5];
            formP6TextBox.Text = parameters_P[6];
            formP7TextBox.Text = parameters_P[7];
            formP8TextBox.Text = parameters_P[8];
            formP9TextBox.Text = parameters_P[9];
        }


        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            List<string> parameters = new List<string>();

            parameters.Add(formP0TextBox.Text);
            parameters.Add(formP1TextBox.Text);
            parameters.Add(formP2TextBox.Text);
            parameters.Add(formP3TextBox.Text);
            parameters.Add(formP4TextBox.Text);
            parameters.Add(formP5TextBox.Text);
            parameters.Add(formP6TextBox.Text);
            parameters.Add(formP7TextBox.Text);
            parameters.Add(formP8TextBox.Text);
            parameters.Add(formP9TextBox.Text);

            try
            {
                switch (aktualna_relacja)
                {
                    case "Petenci":
                        db.PetenciEdit(parameters);
                        break;
                    case "Asystenci":
                        db.AsystenciEdit(parameters);
                        break;
                    case "Typy_pomocy":
                        db.Typy_pomocyEdit(parameters);
                        break;
                    case "Rodzaje_pociagow":
                        db.Rodzaje_pociagowEdit(parameters);
                        break;
                    case "Przewoznicy":
                        db.PrzewoznicyEdit(parameters);
                        break;
                    case "Zestawienia":
                        db.ZestawieniaEdit(parameters);
                        break;
                    case "Relacje":
                        db.RelacjeEdit(parameters);
                        break;
                    case "Stacje":
                        db.StacjeEdit(parameters);
                        break;
                    case "Trasy":
                        db.TrasyEdit(parameters);
                        break;
                    case "Kursy":
                        db.KursyEdit(parameters);
                        break;
                    case "Pomoce":
                        db.PomoceEdit(parameters);
                        break;
                }

                this.Close();
                formularze.Show();
            }
            catch
            {
                new ErrorForm("Podczas edycji wprowadzono niepoprawne dane").Show();
            }
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            formularze.Show();
        }
    }
}
