using DataAccesLayer.Entities;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Usuario
    {
        List<Usuario> GetUsuarios();

        Usuario GetUsuario(int Id);
        Usuario GetUsuarioPorCorreo(string correo);

        Usuario login(string correo,string pass);
        void CambiarRol(Share.Entities.DtoRoles rol);
        Usuario AddUsuario(Usuario us);

        Usuario UpdateUsuario(Usuario us);

        void DeleteUsuario(int Id);

        Pasaje AddPasaje(Pasaje pa, int id);

        List<Usuario> GetConductores();

    }
}
