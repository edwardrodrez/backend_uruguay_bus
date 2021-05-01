using BusinessLayer.cast;
using BusinessLayer.Interfaces;
using Share.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using BusinessLayer.Cast;
using DataAccesLayer.Implementations;

namespace BusinessLayer.Implementations
{
    public class BL_Horario : IBL_Horario
    {
        private IDAL_Horario dal = new DAL_Horario();

        public void DeleteVehiculo(int IdVehiculo, int IdHorario)
        {
            dal.DeleteVehiculo(IdVehiculo, IdHorario);
        }
        public void DeleteUsuario(int IdUsuario, int IdHorario)
        {
            dal.DeleteUsuario(IdUsuario, IdHorario);
        }
        public void DeleteLinea(int IdLinea, int IdHorario)
        {
            dal.DeleteLinea(IdLinea, IdHorario);
        }

        public void DeleteHorario(int Id)
        {
            dal.DeleteHorario(Id);
        }

        public Horario GetHorario(int Id)
        {
            return castHorario.cast(dal.GetHorario(Id));
        }

        public List<Horario> GetHorario()
        {
            return castHorario.castList(dal.GetHorario());   
        }

        public Horario UpdateHorario(Horario Horario)
        {
            return castHorario.cast(dal.UpdateHorario(castHorario.cast(Horario)));
        }

        public Vehiculo AddVehiculo(int IdVehiculo, int IdHorario)
        {
            return castVehiculo.cast(dal.AddVehiculo(IdVehiculo, IdHorario));
        }

        public Usuario AddUsuario(int IdUsuario, int IdHorario)
        {
            return castUsuario.cast(dal.AddUsuario(IdUsuario, IdHorario));
        }

        public Linea AddLinea(int IdLinea, int IdHorario)
        {
            return castLinea.cast(dal.AddLinea(IdLinea, IdHorario));
        }

        public Horario AddHorario(Horario Horario)
        {
            return castHorario.cast(dal.AddHorario(castHorario.cast(Horario)));
        }

        public Horario AddHorario(Share.Entities.DtoHorario dt)
        {
            return castHorario.cast(dal.AddHorario(dt));
        }
    }
}
