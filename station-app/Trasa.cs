using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_app
{
    class Trasa
    {
        public int Id_trasy { get; set; }

        public DateTime Godzina_przyjazdu { get; set; }
        
        public DateTime Godzina_odjazdu { get; set; }

        public int Fk_ID_relacji { get; set; }

        public int Fk_ID_stacji { get; set; }
    }
}
