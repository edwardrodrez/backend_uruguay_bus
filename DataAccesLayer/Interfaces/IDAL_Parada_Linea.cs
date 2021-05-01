using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interfaces
{
   public interface IDAL_Parada_Linea
    {
       Parada_linea AddParada_Linea(Parada_linea pl);
        void AddParada(int id,int idp);
        void AddLinea(int id,int idl);

    }
}
