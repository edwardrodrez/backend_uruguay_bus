﻿using Share.Enums;
using System;
using System.Collections.Generic;

namespace Share.Entities
{
    public class Viaje
    {
        public int idViaje { get; set; }
        public bool estado { get; set; } = false;
        public Horario horario { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }
        public List<Pasaje> pasajes { get; set; } = new List<Pasaje>();
        public List<Asiento> asientos { get; set; } = new List<Asiento>();
        public List<Dia> DiasViaje { get; set; } = new List<Dia>();
        public Localizacion localizacion { get; set; }
        public Viaje()
        {
            DiasViaje = new List<Dia>();
        }

       
    }
}
