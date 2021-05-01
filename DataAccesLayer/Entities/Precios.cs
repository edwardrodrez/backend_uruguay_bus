using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Precios
    {
        [Key]
        public int idPrecio { get; set; }
        public int precio { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int? idAnterior { get; set; }

        [ForeignKey("idAnterior")]
        public virtual ParadaAnterior ParadaAnterior { get; set; }

    }
}
