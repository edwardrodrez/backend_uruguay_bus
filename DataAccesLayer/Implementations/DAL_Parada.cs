using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DataAccesLayer.Entities;

namespace DataAccesLayer.Implementations
{
    public class DAL_Parada : IDAL_Parada
    {
        public void DeleteParada(int idParada)
        {
            try
            {
                var DB = new Context.AppContext();
                Parada par = DB.Parada.Find(idParada);
                DB.Parada.Remove(par);
                DB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public Parada GetParada(int Id)
        {
            try
            {
                var DB = new Context.AppContext();
                Parada par = DB.Parada.FirstOrDefault(p => p.idParada == Id);
                return par;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Parada> GetParadas()
        {
            try
            {
                var DB = new Context.AppContext();

                return DB.Parada.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Parada UpdateParada(Parada para)
        {
            try
            {
                var DB = new Context.AppContext();
                Parada pa = DB.Parada.FirstOrDefault(x => x.idParada == para.idParada);
                pa.geoReferencia = para.geoReferencia;
                pa.nombre = para.nombre;
                DB.SaveChanges();
                return para;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Parada_linea AddParada_linea(Parada_linea pl, int idParada)
        {
            try
            {

                var DB = new Context.AppContext();
                Parada pa = DB.Parada.FirstOrDefault(x => x.idParada == idParada);
                if (pa != null)
                {
                    pa.Linea.Add(pl);
                }
                DB.SaveChanges();
                return pl;


            }
            catch (Exception)
            {
                throw;
            }

        }
        public Parada AddParada(Parada para)
        {
            try
            {
                var DB = new Context.AppContext();
                DB.Parada.Add(para);
                DB.SaveChanges();
                return para;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
