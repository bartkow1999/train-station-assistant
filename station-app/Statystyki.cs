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
    public partial class StatystykiForm : Form
    {
        EkranGlownyForm ekranGlowny;
        DataAccess db = new DataAccess();

        public StatystykiForm(EkranGlownyForm ekran)
        {
            InitializeComponent();
            ekranGlowny = ekran;
        }

        private void wyliczButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string data_od = odDateTimePicker.Value.ToString("yyyy/MM/dd");
                //string data_do = doDateTimePicker.Value.ToString("yyyy/MM/dd");
                DateTime data_od = odDateTimePicker.Value;
                DateTime data_do = doDateTimePicker.Value;

                //liczbaKursowTextBox.Text = db.GetTableCount("kursy", "data", data_od, data_do); // przeciążenie GetTableCount()
                liczbaKursowTextBox.Text = db.GetKursyCount_function(data_od, data_do);
                liczbaPetentowTextBox.Text = db.GetTableCount("petenci");
                liczbaZgloszenPomocyTextBox.Text = db.GetTableCount("pomoce", "data_zgloszenia", data_od, data_do);
                srednieOpoznienieTextBox.Text = db.GetAverageTime();
            }
            catch
            {
                new ErrorForm("W danym okresie do aplikacji zostało wprowadzone za mało danych. Program nie może wyliczyć statystyk").Show();
            }

        }
        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ekranGlowny.Show();
        }
    }
}
