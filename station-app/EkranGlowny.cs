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
    public partial class EkranGlownyForm : Form
    {
        public EkranGlownyForm()
        {
            InitializeComponent();
        }

        private void rozkladJazdyButton_Click(object sender, EventArgs e)
        {
            RozkladJazdyForm rozkladJazdy = new RozkladJazdyForm(this);
            //rozkladJazdy.ShowDialog();
            rozkladJazdy.Show();
            this.Hide();
        }

        private void statystykiButton_Click(object sender, EventArgs e)
        {
            StatystykiForm statystyki = new StatystykiForm(this);
            statystyki.Show();
            this.Hide();
        }

        private void formularzeButton_Click(object sender, EventArgs e)
        {
            FormularzeForm formularze = new FormularzeForm(this);
            formularze.Show();
            this.Hide();
        }

        private void harmonogramPomocyButton_Click(object sender, EventArgs e)
        {
            HarmonogramPomocyForm pomoce = new HarmonogramPomocyForm(this);
            pomoce.Show();
            this.Hide();
        }
        private void wyjdzButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
