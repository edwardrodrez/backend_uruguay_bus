using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class Horario
    {
        [Key]
        
        public int idHorario { get; set; }  
        public DateTime hora { get; set; }
        //Listas o referencias
        public int? idLinea { get; set; }
        [ForeignKey("idLinea")]
        public virtual Linea linea { get; set; }

        public int? idVehiculo { get; set; }
        [ForeignKey("idVehiculo")]
        public virtual Vehiculo vehiculo { get; set; }

        public int? idUsuario { get; set; }
        [ForeignKey("idUsuario")]
        public virtual Usuario usuario { get; set; }

        public int? idViaje { get; set; }
        [ForeignKey("idViaje")]
        public Viaje viaje { get; set; }

    }
}
