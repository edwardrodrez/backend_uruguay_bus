using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Asiento
    {

        [Key]
        public int idAsiento { get; set; }
        public bool disponible { get; set; }
        public int? nroAsiento { get; set; }

        public int? idViaje { get; set; }

        [ForeignKey("idViaje")]
        public virtual Viaje viaje { get; set; }
        public virtual List<Pasaje> pasajes { get; set; } = new List<Pasaje>();
    }
}
