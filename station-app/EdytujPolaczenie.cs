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
    public partial class EdytujPolaczenieForm : Form
    {
        RozkladJazdyForm rozkladJazdy;
        DataAccess db = new DataAccess();

        public EdytujPolaczenieForm(RozkladJazdyForm rozklad, List<string> parameters)
        {
            rozkladJazdy = rozklad;
            InitializeComponent();
            LoadElements(parameters);
        }

        public void LoadElements(List<string> parameters)
        {
            id_kursuTextBox.Text = parameters[0];
            dataDateTimePicker.Value = DateTime.Parse(parameters[1]);
            stacja_poczatkowaTextBox.Text = parameters[2];
            stacja_koncowaTextBox.Text = parameters[3];
            godzinaOdjazduDateTimePicker.Value = DateTime.Parse(parameters[4]);
            peronTextBox.Text = parameters[5];
            opoznienieTextBox.Text = parameters[6];
            uwagiTextBox.Text = parameters[7];
            fk_id_relacjiTextBox.Text = parameters[8];
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

                db.EdytujPolaczenie(parameters);

                this.Close();
                rozkladJazdy.Show();
            }
            catch
            {
                new ErrorForm("Podczas edycji wprowadzono niepoprawne dane").Show();
            }
        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            rozkladJazdy.Show();
        }
    }
}
