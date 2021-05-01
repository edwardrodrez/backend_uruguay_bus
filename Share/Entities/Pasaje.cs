using Share.Enums;
using System;

namespace Share.Entities
{
    public class Pasaje
    {
        public int idPasaje { get; set; }
        public DateTime fecha { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public int posicionOrigen { get; set; }
        public string nombreOrigen { get; set; }
        public int posicionDestino { get; set; }
        public string nombreDestino{ get; set; }
        public string codigo { get; set; }
        public int precio { get; set; }
        public Asiento asiento { get; set; }

    }
}
