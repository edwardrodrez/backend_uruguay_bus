using Share.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccesLayer.Entities
{
    public class Viaje
    {
        [Key]
        public int idViaje { get; set; }
        public bool estado { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

        public int? idlocalizacion { get; set; }
        [ForeignKey("idlocalizacion")]
        public Localizacion localizacion { get; set; }

        //public int? idHorario { get; set; }
        //[ForeignKey("idHorario")]
        [Required]
        public virtual Horario horario { get; set; }

        public virtual List<Pasaje> pasajes { get; set; } = new List<Pasaje>();
        public virtual List<Asiento> asientos { get; set; } = new List<Asiento>();

        public virtual List<Dia> DiasViaje { get; set; } = new List<Dia>();
        public Viaje()
        {
            DiasViaje = new List<Dia>();
        }
    }
}
