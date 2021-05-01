using System.Collections.Generic;

namespace Share.Entities
{
    public class Parada
    {
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
