using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccesLayer.Implementations
{
    public class DAL_vehiculo : IDAL_vehiculo
    {


        public void DeleteVehiculo(int Id)
        {
            var db = new Context.AppContext();
            Vehiculo e = db.Vehiculo.Find(Id);
            db.Vehiculo.Remove(e);
            db.SaveChanges();
        }

        public Vehiculo GetVehiculo(int Id)
        {
            var db = new Context.AppContext();
            return db.Vehiculo.FirstOrDefault(x => x.idVehiculo == Id);
        }

        public List<Vehiculo> GetVehiculos()
        {
            var db = new Context.AppContext();
            return db.Vehiculo.ToList();
        }

        public Vehiculo UpdateVehiculo(Vehiculo vehiculo)
        {
            using (var db = new Context.AppContext())
            {
                Vehiculo v = db.Vehiculo.FirstOrDefault(x => x.idVehiculo == vehiculo.idVehiculo);
                v.cantAsientos = vehiculo.cantAsientos;
                v.marca = vehiculo.marca;
                v.matricula = vehiculo.matricula;
                v.modelo = vehiculo.modelo;
                db.SaveChanges();
            }
            return vehiculo;
        }

        public Vehiculo AddVehiculo(Vehiculo vehiculo)
        {
            var db = new Context.AppContext();
            db.Vehiculo.Add(vehiculo);
            var res = db.SaveChanges();
            return vehiculo;
        }
    }
}
