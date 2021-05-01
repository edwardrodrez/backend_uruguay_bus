using System.Collections.Generic;

namespace Share.Entities
{
    public class Linea
    {
        public int idLinea { get; set; }
        public string nombre { get; set; }
        public List<ParadaAnterior> ParadaAnterior { get; set; } = new List<ParadaAnterior>();
        public List<Parada_linea> Parada { get; set; } = new List<Parada_linea>();
        public List<Horario> Horarios { get; set; } = new List<Horario>();

        public Linea()
        {
            ParadaAnterior = new List<ParadaAnterior>();
            Parada = new List<Parada_linea>();
            Horarios = new List<Horario>();
        }
    }
}
