using Share.Entities;
using Share.Enums;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Viaje
    {
        List<Viaje> GetViajes();

        Viaje GetViaje(int Id);

        Viaje AddViaje(DtoViaje vi);

        Viaje UpdateViaje(Viaje vi);

        void DeleteViaje(int Id);

        Pasaje AddPasaje(Pasaje pa, int id);

        Asiento AddAsiento(Asiento a, int id);

        Dia AddDia(Dia di, int id);

        List<DtViajeChofer> ViajesChofer(int id);

        void comensarViaje(int id);

        List<DtoViajePrecio> ViajePasaje(DtoViajePasaje dto);

        bool ComprarPasaje(DtoComprarPasaje dto);

        DtoValidarRet ValidarPasaje(DtoValidar dto);

        List<DtoViajeControl> ViajeControl();

        string MoverVehiculo(int id);

        List<DtoProximoVehiculoRet> ProximoVehiculo(DtoProximoVehiculo dto);

        List<ReporteRet> Reportes(Reporte dto);
        
    }
}
