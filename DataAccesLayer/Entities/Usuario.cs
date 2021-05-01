using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Entities
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public DateTime? fechaLibreta { get; set; }
        public string Token { get; set; }


        //Listas o referencias
        public List<Horario> horarios { get; set; }
        public List<Pasaje> pasajes { get; set; }

         public Usuario()
        {
            horarios = new List<Horario>();
        }

    }
}
