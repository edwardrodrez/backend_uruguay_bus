using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Parada_Linea :IDAL_Parada_Linea
    {

        public Parada_linea AddParada_Linea(Parada_linea para)
        {           
                var DB = new Context.AppContext();
                DB.Paradalinea.Add(para);
                DB.SaveChanges();
                return para;         
        }
        public void AddLinea(int id,int l)
        {
            var DB = new Context.AppContext();
            Parada_linea pa = DB.Paradalinea.Find(id);
            pa.Linea = DB.Linea.Find(l);
            DB.SaveChanges();
        }

        public void AddParada(int id,int p)
        {
            var DB = new Context.AppContext();
            Parada_linea pa = DB.Paradalinea.Find(id);
            pa.Parada = DB.Parada.Find(p);
            DB.SaveChanges();
        }

    }
}
