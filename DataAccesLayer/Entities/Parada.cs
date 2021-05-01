using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Entities
{
    public class Parada
    {
        [Key]
        public int idParada { get; set; }
        public string nombre { get; set; }
        public string geoReferencia { get; set; }
        public List<Parada_linea> Linea { get; set; } = new List<Parada_linea>();
        public Parada()
        {
            Linea = new List<Parada_linea>();
        }
    }
}
