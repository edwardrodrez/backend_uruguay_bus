using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Entities
{
    public class Vehiculo
    {
        [Key]
        public int idVehiculo { get; set; }
        public string matricula { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public int cantAsientos { get; set; }

        //Listas o referencias
        public List<Horario> horarios { get; set; }



    }
}
