using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Viaje
    {
        List<Viaje> GetViajes();

        Viaje GetViaje(int Id);

        Viaje AddViaje(Share.Entities.DtoViaje vi, List<Dia> dias,int cantidad);

        Viaje UpdateViaje(Viaje vi);

        void DeleteViaje(int Id);

        Pasaje AddPasaje(Pasaje pa, int idViaje,int idusuario,int idAsiento);

        Pasaje AddPasajePlatafoma(Pasaje pa, int idViaje, int idAsiento);

        Asiento AddAsiento(Asiento a, int id);
        Dia AddDia(Dia di, int id);

        List<Viaje> ViajesChofer(int id);

        void comensarViaje(int id, DateTime hora);

        List<Viaje> ViajePasaje(Share.Entities.DtoViajePasaje dto,string dia);

        Viaje validarPasaje(Share.Entities.DtoValidar dto);

        List<Viaje> ViajesEnCurso();

        void FinalizarViaje(int id);

        void MoverVehiculo(int id, DateTime hora);

        List<Viaje> ProximoVehiculo(int id);
        //PARA REPORTES
        List<Pasaje> soloPasajes(DateTime f1, DateTime f2);

        List<Linea> lineasConPasajes(DateTime f1, DateTime f2);

        List<Pasaje> pasajesporLinea(DateTime f1, DateTime f2,int idlinea);
        List<Horario> horarioConPasajes(DateTime f1, DateTime f2);
        List<Pasaje> pasajesporHorario(DateTime f1, DateTime f2, DateTime fecha);
        //---
        List<Viaje> viajesConPasajes(DateTime f1, DateTime f2);
        List<Pasaje> pasajesPorViaje(DateTime f1, DateTime f2, int idViaje);
    }
}

