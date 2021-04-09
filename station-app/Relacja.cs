using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_app
{
    class Relacja
    {
        public int Id_relacji { get; set; }

        public string Stacja_poczatkowa { get; set; }

        public string Stacja_koncowa { get; set; }

        public int Fk_ID_rodzaj_pociagu { get; set; }

        public int Fk_ID_przewoznika { get; set; }

        public int Fk_ID_zestawienia { get; set; }
    }
}
