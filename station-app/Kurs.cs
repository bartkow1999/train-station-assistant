using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_app
{
    class Kurs
    {
        public int Id_kursu { get; set; }

        public DateTime Data { get; set; }

        public string Stacja_poczatkowa { get; set; }

        public string Stacja_koncowa { get; set; }
        
        public DateTime Godzina_odjazdu { get; set; }

        public string Peron { get; set; }

        public int Opoznienie { get; set; }

        public string Uwagi { get; set; }

        //public int? Fk_id_relacji { get; set; } // ? - nullable 
        public int Fk_id_relacji { get; set; }

      }
}
