using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Parada_linea
    {
        [Key]
        public int idParada_linea { get; set; }
        public int posicion { get; set; }

        public int? idLinea { get; set; }
        [ForeignKey("idLinea")]
        public virtual Linea Linea { get; set; }

        public int? idParada { get; set; }
        [ForeignKey("idParada")]
        public virtual Parada Parada { get; set; }
    }
}
