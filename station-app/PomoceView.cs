using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_app
{
    class PomoceView
    {
        public int Id_pomocy { get; set; }

        public DateTime Data_zgloszenia { get; set; }

        public DateTime Godzina_zgloszenia { get; set; }

        public int Fk_id_kursu { get; set; }

        public string opis { get; set; }
        public string imie_petenta { get; set; }
        public string nazwisko_petenta { get; set; }
        public int telefon { get; set; }
        public string mail { get; set; }
        public string uwagi { get; set; }
        public string imie_asystenta { get; set; }
        public string nazwisko_asystenta { get; set; }

    }
}
