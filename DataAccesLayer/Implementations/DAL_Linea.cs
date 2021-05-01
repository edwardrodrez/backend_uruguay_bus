using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccesLayer.Implementations
{
    public class DAL_Linea : IDAL_Linea
    {

        public void DeleteParadaAnterior(int IdParadaAnterior)
        {
            var db = new Context.AppContext();
            ParadaAnterior e = db.ParadaAnterior.Find(IdParadaAnterior);
            db.ParadaAnterior.Remove(e);
            db.SaveChanges();
        }
        public void DeleteParada_linea(int IdParada_linea)
        {
            var db = new Context.AppContext();
            ParadaAnterior e = db.ParadaAnterior.Find(IdParada_linea);
            db.ParadaAnterior.Remove(e);
            db.SaveChanges();
        }
        public void DeleteHorario(int IdHorario, int IdLinea)
        {
            var db = new Context.AppContext();
            Linea e = db.Linea.FirstOrDefault(x => x.idLinea == IdLinea);
            Horario e2 = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            if (e != null)
            {
                e.Horarios.Remove(e2);
            }
            db.SaveChanges();
        }

        //NO
        public void DeleteLinea(int Id)
        {
          
        }

        public Linea GetLinea(int Id)
        {
            var db = new Context.AppContext();
            return db.Linea.Include("ParadaAnterior").Include("Parada").Include("Horarios").FirstOrDefault(x => x.idLinea == Id);
        }

        public List<Linea> GetLinea()
        {
            var db = new Context.AppContext();
            return db.Linea.Include("ParadaAnterior").Include("Parada").Include("Horarios").ToList();
        }

        public Linea UpdateLinea(Linea Linea)
        {
            using (var db = new Context.AppContext())
            {
                Linea li = db.Linea.FirstOrDefault(x => x.idLinea == Linea.idLinea);
                li.nombre = Linea.nombre;
                db.SaveChanges();
            }
            return Linea;
        }

        public ParadaAnterior AddParadaAnterior(ParadaAnterior ParadaAnterior, int idLinea)
        {
            var db = new Context.AppContext();
            Linea e = db.Linea.FirstOrDefault(x => x.idLinea == idLinea);
            if (e != null)
            {
                e.ParadaAnterior.Add(ParadaAnterior);
            }
            db.SaveChanges();
            return ParadaAnterior;
        }

        public Parada_linea AddParada_linea(int IdParada_linea, int idLinea)
        {
            var db = new Context.AppContext();
            Linea e = db.Linea.FirstOrDefault(x => x.idLinea == idLinea);
            if (e != null)
            {
                Parada_linea p = db.Paradalinea.FirstOrDefault(x => x.idParada_linea == IdParada_linea);
                if (e != null)
                    e.Parada.Add(p);
            }
            db.SaveChanges();
            Parada_linea p2 = db.Paradalinea.FirstOrDefault(x => x.idParada_linea == IdParada_linea);
            return p2;
        }


        public Horario AddHorario(int IdHorario, int IdLinea)
        {
            var db = new Context.AppContext();
            Linea e = db.Linea.FirstOrDefault(x => x.idLinea == IdLinea);
            Horario e2 = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            if (e != null)
            {
                e.Horarios.Add(e2);
            }
            db.SaveChanges();
            return e2;
        }


        public Linea AddLinea(Linea Linea)
        {
            var db = new Context.AppContext();
            db.Linea.Add(Linea);
            db.SaveChanges();
            return Linea;
        }


        public List<Parada_linea> GetParadas(int id)
        {
            var db = new Context.AppContext();

            return db.Paradalinea.Include("Parada").Where(x => x.idLinea == id).ToList();

        }

        public ParadaAnterior GetParadaAnterior(int id)
        {
            var db = new Context.AppContext();
            return db.ParadaAnterior.Include("Precios").FirstOrDefault(x => x.idAnterior == id);
        }

        public void AddPrecio(Precios pre,int id)
        {
            var db = new Context.AppContext();
            ParadaAnterior pa = db.ParadaAnterior.Include("Precios").FirstOrDefault(x => x.idAnterior == id);
            db.Precio.Add(pre);
            pre.ParadaAnterior = pa;
            pa.Precios.Add(pre);     
            db.SaveChanges();

        }




    }
}
