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
    public partial class ErrorForm : Form
    {
        public ErrorForm(String message = "Wystąpił błąd")
        {
            InitializeComponent();
            messageTextBox.Text = message;
            messageTextBox.Select(0, 0);
        } 

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
