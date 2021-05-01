using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataAccesLayer.Implementations
{
    public class DAL_Horario : IDAL_Horario
    {

        public void DeleteVehiculo(int IdVehiculo, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Vehiculo e2 = db.Vehiculo.FirstOrDefault(x => x.idVehiculo == IdVehiculo);
            if (e != null)
            {
                e2.horarios.Remove(e);
            }
            db.SaveChanges();
        }
        public void DeleteUsuario(int IdUsuario, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Usuario e2 = db.Usuario.FirstOrDefault(x => x.idUsuario == IdUsuario);
            if (e != null)
            {
                e2.horarios.Remove(e);
            }
            db.SaveChanges();
        }
        public void DeleteLinea(int IdLinea, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Linea e2 = db.Linea.FirstOrDefault(x => x.idLinea == IdLinea);
            if (e != null)
            {
                e2.Horarios.Remove(e);
            }
            db.SaveChanges();
        }

        public void DeleteHorario(int Id)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.Find(Id);
            db.Horario.Remove(e);
            db.SaveChanges();
        }

        public Horario GetHorario(int Id)
        {
            var db = new Context.AppContext();
            return db.Horario.Include("viaje").Include("vehiculo").Include("usuario").FirstOrDefault(x => x.idHorario == Id);
        }

        public List<Horario> GetHorario()
        {
            var db = new Context.AppContext();
            return db.Horario.Include("viaje").Include("vehiculo").Include("usuario").ToList();
        }

        public Horario UpdateHorario(Horario Horario)
        {
            using (var db = new Context.AppContext())
            {
                Horario ho = db.Horario.FirstOrDefault(x => x.idHorario == Horario.idHorario);
                ho.hora = Horario.hora;
                db.SaveChanges();
            }
            return Horario;
        }

        public Vehiculo AddVehiculo(int IdVehiculo, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Vehiculo e2 = db.Vehiculo.FirstOrDefault(x => x.idVehiculo == IdVehiculo);
            if (e != null)
            {
                e2.horarios.Add(e);
            }
            db.SaveChanges();
            return e2;
        }

        public Usuario AddUsuario(int IdUsuario, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Usuario e2 = db.Usuario.FirstOrDefault(x => x.idUsuario == IdUsuario);
            if (e != null)
            {
                e2.horarios.Add(e);
            }
            db.SaveChanges();
            return e2;
        }

        public Linea AddLinea(int IdLinea, int IdHorario)
        {
            var db = new Context.AppContext();
            Horario e = db.Horario.FirstOrDefault(x => x.idHorario == IdHorario);
            Linea e2 = db.Linea.FirstOrDefault(x => x.idLinea == IdLinea);
            if (e != null)
            {
                e2.Horarios.Add(e);
            }
            db.SaveChanges();
            return e2;
        }

        public Horario AddHorario(Horario Horario)
        {
            var db = new Context.AppContext();
            db.Horario.Add(Horario);
            var res = db.SaveChanges();
            return Horario;
        }

        public Horario AddHorario(Share.Entities.DtoHorario dt)
        {

            var db = new Context.AppContext();

            Horario Horario = new Horario() {       
                hora = dt.hora,
                idLinea = dt.idlinea,
                idUsuario = dt.idusuario,
                idVehiculo = dt.idvehiculo
            };
            db.Horario.Add(Horario);
            db.SaveChanges();
            return Horario;
        }


    }
}
