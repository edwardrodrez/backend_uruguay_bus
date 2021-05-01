using System;

namespace Share.Entities
{
    public class Horario
    {
        public int idHorario { get; set; }
        public DateTime hora { get; set; }
        //Listas o referencias
        public Linea linea { get; set; }
        public Vehiculo vehiculo { get; set; }
        public Usuario usuario { get; set; }

        public bool Viaje { get; set; }

    }
}
