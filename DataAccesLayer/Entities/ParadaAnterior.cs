using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesLayer.Entities
{
    public class ParadaAnterior
    {
        [Key]
        public int idAnterior { get; set; }
        public int posicion { get; set; }
        public DateTime tiempo { get; set; }
        public List<Precios> Precios { get; set; } = new List<Precios>();
        public ParadaAnterior()
        {
            Precios = new List<Precios>();
        }
        public int? idLinea { get; set; }

        [ForeignKey("idLinea")]
        public virtual Linea linea { get; set; }

    }
}
