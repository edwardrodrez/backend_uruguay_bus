using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataAccesLayer.Entities;

namespace DataAccesLayer.Implementations
{
    public class DAL_Precios : IDAL_Precios
    {
        public void DeletePrecio(int idPrecio)
        {
            
                var DB = new Context.AppContext();
                Precios pre = DB.Precio.Find(idPrecio);
                DB.Precio.Remove(pre);
                DB.SaveChanges();
           
        }



        public Precios GetPrecio(int Id)
        {
            
                var DB = new Context.AppContext();
                Precios pre = DB.Precio.FirstOrDefault(p => p.idPrecio == Id);
                return pre;
            
        }

        public List<Precios> GetPrecios()
        {
           
                var DB = new Context.AppContext();

                return DB.Precio.ToList();

           
        }

        public Precios UpdatePrecio(Precios pre)
        {
            
            var DB = new Context.AppContext();
            Precios p = DB.Precio.FirstOrDefault(x => x.idPrecio == pre.idPrecio);
            p.precio = pre.precio;
            DB.SaveChanges();
            return pre;
          
        }
       
        public Precios AddPrecio(Precios pre)
        {
            
                var DB = new Context.AppContext();
                DB.Precio.Add(pre);
                DB.SaveChanges();
                return pre;
           
        }

    }
}
