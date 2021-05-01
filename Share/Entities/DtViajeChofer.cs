using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Entities
{
    public class DtViajeChofer
    {
        public int idViaje { get; set; }
        public bool estado { get; set; } = false;
        public Horario horario { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public Localizacion localizacion { get; set; }

    }
}