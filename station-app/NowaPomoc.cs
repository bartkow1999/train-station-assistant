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
    public partial class NowaPomoc : Form
    {
        HarmonogramPomocyForm pomoce;
        DataAccess db = new DataAccess();

        public NowaPomoc(HarmonogramPomocyForm rozklad)
        {
            try
            {
                InitializeComponent();
                pomoce = rozklad;
                id_pomocyTextBox.Text = db.GetSeqNextVal("ID_pomocy").ToString();
            }
            catch
            {
                new ErrorForm("Nie udało się poprawnie odczytać ID!").Show();
            }
        }

        public void LoadElements(List<string> parameters)
        {
            id_pomocyTextBox.Text = parameters[0];
            dataDateTimePicker.Value = DateTime.Parse(parameters[1]);
            data2dateTimePicker.Value = DateTime.Parse(parameters[2]);
            fk_ID_kursu.Text = parameters[3];
            fk_id_petenta.Text = parameters[4];
            fk_id_asystenta.Text = parameters[5];
            fk_id_typu_pomocy.Text = parameters[6];
        }

        private void zatwierdzButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> parameters = new List<string>();
                parameters.Add(id_pomocyTextBox.Text);
                parameters.Add(dataDateTimePicker.Value.ToString());
                parameters.Add(data2dateTimePicker.Value.ToString());
                parameters.Add(string.IsNullOrEmpty(fk_ID_kursu.Text) ? "0" : fk_ID_kursu.Text);
                parameters.Add(string.IsNullOrEmpty(fk_id_petenta.Text) ? "0" : fk_id_petenta.Text);
                parameters.Add(string.IsNullOrEmpty(fk_id_asystenta.Text) ? "0" : fk_id_asystenta.Text);
                parameters.Add(string.IsNullOrEmpty(fk_id_typu_pomocy.Text) ? "0" : fk_id_typu_pomocy.Text);

                db.DodajPomoc(parameters);
                this.Close();
                pomoce.Show();
            }
            catch
            {
                new ErrorForm("Podano niepoprawne dane!").Show();
            }

        }

        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            pomoce.Show();
        }

    }
}
