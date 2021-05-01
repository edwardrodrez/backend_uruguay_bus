
using Share.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Pasaje
    {
        [Key]
        public int idPasaje { get; set; }
        public DateTime fecha { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public int posicionOrigen { get; set; }
        public int posicionDestino { get; set; }
        public string nombreOrigen { get; set; }
        public string nombreDestino { get; set; }
        public string codigo { get; set; }
        public int precio { get; set; }

        public int? idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario usuario { get; set; }

        public int? idViaje { get; set; }
        [ForeignKey("idViaje")]
        public virtual Viaje viaje { get; set; }

        public int? idAsiento { get; set; }
        [ForeignKey("idAsiento")]
        public virtual Asiento asiento { get; set; }
    }
}
