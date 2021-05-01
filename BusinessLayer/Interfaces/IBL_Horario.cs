using Share.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Horario
    {
        List<Horario> GetHorario();

        Horario GetHorario(int Id);

        Horario AddHorario(Horario Horario);
        Horario AddHorario(Share.Entities.DtoHorario dt);

        Horario UpdateHorario(Horario Horario);

        void DeleteHorario(int Id);

        Vehiculo AddVehiculo(int IdVehiculo, int IdHorario);
        Usuario AddUsuario(int IdUsuario, int IdHorario);
        Linea AddLinea(int IdLinea, int IdHorario);

        void DeleteVehiculo(int IdVehiculo, int IdHorario);
        void DeleteUsuario(int IdUsuario, int IdHorario);
        void DeleteLinea(int IdLinea, int IdHorario);

    }
}
