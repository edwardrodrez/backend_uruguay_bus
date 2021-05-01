using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Localizacion
    {
        [Key]
        public int idlocalizacion { get; set; }
        public int? ultimaPosicion { get; set; }
        public DateTime HoraDeLlegada { get; set; }
 
    }
}
