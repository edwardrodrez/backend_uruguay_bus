using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class Dia
    {
        [Key]
        public int idDia { get; set; }
        public string nombre { get; set; }
        public List<Viaje> viaje { get; set; }
    }
}
