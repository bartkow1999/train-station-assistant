using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace station_app
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool go = true;
            while (go)
            {
                try
                {
                    Application.Run(new EkranGlownyForm());
                    go = false;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException)
                {
                    new ErrorForm("Brak połączenia z bazą").Show();
                }
            }
        }
    }
}
