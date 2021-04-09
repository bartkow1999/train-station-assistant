using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace station_app
{
    class Pomoc
    {
        public int Id_pomocy { get; set; }

        public DateTime Data_zgloszenia { get; set; }

        public DateTime Godzina_zgloszenia { get; set; }

        public int Fk_id_kursu { get; set; }

        public int Fk_id_petenta { get; set; }

        public int Fk_id_asystenta { get; set; }

        public int Fk_id_typu_pomocy { get; set; }
      
    }
}
