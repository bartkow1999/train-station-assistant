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
    public partial class NowyFormularzForm : Form
    {
        FormularzeForm formularze;
        DataAccess db = new DataAccess();
        string aktualna_relacja;

        public NowyFormularzForm(FormularzeForm form, string relacja, List<string> parameters)
        {
            InitializeComponent();
            formularze = form;
            aktualna_relacja = relacja;

            LoadElements(parameters);
        }

        private void LoadElements(List<string> parameters)
        {
            formL0TextBox.Text = parameters[0];
            formL1TextBox.Text = parameters[1];
            formL2TextBox.Text = parameters[2];
            formL3TextBox.Text = parameters[3];
            formL4TextBox.Text = parameters[4];
            formL5TextBox.Text = parameters[5];
            formL6TextBox.Text = parameters[6];
            formL7TextBox.Text = parameters[7];
            formL8TextBox.Text = parameters[8];
            formL9TextBox.Text = parameters[9];

            try
            {
                switch (aktualna_relacja)
                {
                    case "Petenci":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_petenta").ToString();
                        break;
                    case "Asystenci":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_asystenta").ToString();
                        break;
                    case "Typy_pomocy":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_typu_pomocy").ToString();
                        break;
                    case "Rodzaje_pociagow":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_rodzaju_pociagu").ToString();
                        break;
                    case "Przewoznicy":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_przewoznika").ToString();
                        break;
                    case "Zestawienia":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_zestawienia").ToString();
                        break;
                    case "Relacje":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_relacji").ToString();
                        break;
                    case "Stacje":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_stacji").ToString();
                        break;
                    case "Trasy":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_trasy").ToString();
                        break;
                    case "Kursy":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_kursu").ToString();
                        break;
                    case "Pomoce":
                        formP0TextBox.Text = db.GetSeqNextVal("ID_pomocy").ToString();
                        break;
                }
            }
            catch
            {
                new ErrorForm("Nie udało się poprawnie odczytać ID!").Show();
            }
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
                        db.PetenciAdd(parameters);
                        break;
                    case "Asystenci":
                        db.AsystenciAdd(parameters);
                        break;
                    case "Typy_pomocy":
                        db.Typy_pomocyAdd(parameters);
                        break;
                    case "Rodzaje_pociagow":
                        db.Rodzaje_PociagowAdd(parameters);
                        break;
                    case "Przewoznicy":
                        db.PrzewoznicyAdd(parameters);
                        break;
                    case "Zestawienia":
                        db.ZestawieniaAdd(parameters);
                        break;
                    case "Relacje":
                        db.RelacjeAdd(parameters);
                        break;
                    case "Stacje":
                        db.StacjeAdd(parameters);
                        break;
                    case "Trasy":
                        db.TrasyAdd(parameters);
                        break;
                    case "Kursy":
                        db.KursyAdd(parameters);
                        break;
                    case "Pomoce":
                        db.PomoceAdd(parameters);
                        break;
                }
                this.Close();
                formularze.Show();
            }
            catch
            {
                new ErrorForm("Podano niepoprawne dane!").Show();
            }
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            formularze.Show();
        }
    }
}
