
using DataAccesLayer.Entities;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_vehiculo
    {
        List<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(int Id);

        Vehiculo AddVehiculo(Vehiculo vehiculo);

        Vehiculo UpdateVehiculo(Vehiculo vehiculo);

        void DeleteVehiculo(int Id);

    }
}
