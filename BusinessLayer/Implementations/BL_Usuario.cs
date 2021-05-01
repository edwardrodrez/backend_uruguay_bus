using BusinessLayer.cast;
using BusinessLayer.Interfaces;
using Share.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using BusinessLayer.Cast;
using DataAccesLayer.Implementations;

namespace BusinessLayer.Implementations
{
    public class BL_Usuario : IBL_Usuario
    {
        private IDAL_Usuario dal = new DAL_Usuario();
        public void DeleteUsuario(int id)
        {
            dal.DeleteUsuario(id);
        }

        public Usuario GetUsuario(int Id)
        {
           return castUsuario.cast(dal.GetUsuario(Id));
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {
            return castUsuario.cast(dal.GetUsuarioPorCorreo(correo));
        }

        public Usuario login(string correo, string pass)
        {
            return castUsuario.cast(dal.login(correo,pass));
        }

        public void CambiarRol(DtoRoles rol)
        {
             dal.CambiarRol(rol);
        }
        public List<Usuario> GetUsuarios()
        {
            return castUsuario.castList(dal.GetUsuarios());
        }

        public Usuario UpdateUsuario(Usuario us)
        {
            return castUsuario.cast(dal.UpdateUsuario(castUsuario.cast(us)));
        }

        public Pasaje AddPasaje(Pasaje pa, int id)
        {
            return castPasaje.cast(dal.AddPasaje(castPasaje.cast(pa), id));
        }
        public Usuario AddUsuario(Usuario us)
        {
            return castUsuario.cast(dal.AddUsuario(castUsuario.cast(us)));
        }
        public List<Usuario> GetConductores()
        {
            return castUsuario.castList(dal.GetConductores());
        }

    }
}

