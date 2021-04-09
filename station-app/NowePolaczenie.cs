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
    public partial class NowePolaczenieForm : Form
    {
        RozkladJazdyForm rozkladJazdy;
        DataAccess db = new DataAccess();

        public NowePolaczenieForm(RozkladJazdyForm rozklad)
        {
            try
            {
                InitializeComponent();
                rozkladJazdy = rozklad;
                id_kursuTextBox.Text = db.GetSeqNextVal("ID_kursu").ToString();
            }
            catch
            {
                new ErrorForm("Nie udało się poprawnie odczytać ID!").Show();
            }
        }

        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> parameters = new List<string>();
                parameters.Add(id_kursuTextBox.Text);
                parameters.Add(dataDateTimePicker.Value.ToString());
                parameters.Add(stacja_poczatkowaTextBox.Text);
                parameters.Add(stacja_koncowaTextBox.Text);
                parameters.Add(godzinaOdjazduDateTimePicker.Value.ToString());
                parameters.Add(peronTextBox.Text);
                parameters.Add(opoznienieTextBox.Text);
                parameters.Add(uwagiTextBox.Text);
                parameters.Add(string.IsNullOrEmpty(fk_id_relacjiTextBox.Text) ? "0" : fk_id_relacjiTextBox.Text);

                db.DodajPolaczenie(parameters);
                this.Close();
                rozkladJazdy.Show();
            }
            catch
            {
                new ErrorForm("Podano niepoprawne dane!").Show();
            }
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            rozkladJazdy.Show();
        }
    }
}
