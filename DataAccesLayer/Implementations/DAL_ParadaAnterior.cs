using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_ParadaAnterior :IDAL_ParadaAnterior
    {

        public ParadaAnterior AddParadaAnterior(ParadaAnterior para)
        {           
                var DB = new Context.AppContext();
                DB.ParadaAnterior.Add(para);
                DB.SaveChanges();
                return para;         
        }

        public void AddPrecio(int id,Precios pr)
        {
            var DB = new Context.AppContext();
            ParadaAnterior p = DB.ParadaAnterior.Find(id);
            p.Precios.Add(pr);
            DB.SaveChanges();

        }

        public void AddLinea(int id,int l)
        {
            var DB = new Context.AppContext();
            ParadaAnterior p = DB.ParadaAnterior.Find(id);
            p.linea = DB.Linea.Find(l);
            DB.SaveChanges();

        }

    }
}
