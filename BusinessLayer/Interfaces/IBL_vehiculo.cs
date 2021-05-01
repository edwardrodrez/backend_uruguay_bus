using System.Collections.Generic;
using Share.Entities;
namespace DataAccesLayer.Interfaces
{
    public interface IBL_vehiculo
    {
        List<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(int Id);

        Vehiculo AddVehiculo(Vehiculo vehiculo);

        Vehiculo UpdateVehiculo(Vehiculo vehiculo);

        void DeleteVehiculo(int Id);

    }
}
