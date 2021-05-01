using System.Collections.Generic;

namespace Share.Entities
{
    public class Vehiculo
    {
        public int idVehiculo { get; set; }
        public string matricula { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public int cantAsientos { get; set; }

        //Listas o referencias
        public List<Horario> horarios { get; set; }



    }
}
