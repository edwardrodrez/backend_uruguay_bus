using Share.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Usuario
    {
        List<Usuario> GetUsuarios();

        Usuario GetUsuario(int Id);
        Usuario GetUsuarioPorCorreo(string correo);
        Usuario login(string correo,string pass);
        Usuario AddUsuario(Usuario us);

        void CambiarRol(DtoRoles rol);

        Usuario UpdateUsuario(Usuario us);

        void DeleteUsuario(int Id);

        Pasaje AddPasaje(Pasaje pa, int id);

        List<Usuario> GetConductores();

    }
}
