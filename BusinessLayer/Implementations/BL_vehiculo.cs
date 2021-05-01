
using BusinessLayer.cast;
using DataAccesLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Implementations
{

    public class BL_vehiculo : IBL_vehiculo
    {
        private IBL_vehiculo dal;
        IDAL_vehiculo IDAL = new DAL_vehiculo();

        public BL_vehiculo()
        {
        }

        public BL_vehiculo(IBL_vehiculo _dal)
        {
            dal = _dal;
        }


        public Vehiculo AddVehiculo(Vehiculo vehiculo)
        {
            return castVehiculo.cast(IDAL.AddVehiculo(castVehiculo.cast(vehiculo)));
        }

        public void DeleteVehiculo(int Id)
        {
            IDAL.DeleteVehiculo(Id);
        }

        public List<Vehiculo> GetVehiculos()
        {
            return castVehiculo.castList(IDAL.GetVehiculos());
        }

        public Vehiculo GetVehiculo(int Id)
        {
            return castVehiculo.cast(IDAL.GetVehiculo(Id));
        }

        public Vehiculo UpdateVehiculo(Vehiculo vehiculo)
        {
            return castVehiculo.cast(IDAL.UpdateVehiculo(castVehiculo.cast(vehiculo)));
        }
    }
}
