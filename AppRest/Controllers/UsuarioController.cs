
using System.Collections.Generic;
using System.Web.Http;
using AppRest.Cast;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using WEBAPI_CustomAuth.CustomIdentity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers
{
    [RoutePrefix("api/Usuario")]

    public class UsuarioController : ApiController
    {

        IBL_Usuario con = new BL_Usuario();
        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return con.GetUsuarios();
        }

        // GET api/<UsuarioController>/5
        [HttpGet]
        public Usuario Get(int id)
        {
            return con.GetUsuario(id);
        }

        [Route("login")]
        [HttpPost]
        public User login(string correo, string pass)
        {

            User us = castUser.cast(con.GetUsuarioPorCorreo(correo));

            if (us != null)
            {
                return null;
            }

            if (us.password == pass)
            {
                return us;
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        [Route("Correo")]
        public Usuario GetPorCorreo(DtoString correo)
        {
            return con.GetUsuarioPorCorreo(correo.variable);
        }

        [HttpPost]
        [Route("CorreoUser")]
        public User GetPorCorreoUser(DtoString correo)
        {
            return castUser.cast(con.GetUsuarioPorCorreo(correo.variable));
        }


        [HttpPost]
        [Route("Rol")]
        public void CambiarRol(DtoRoles rol)
        {
            con.CambiarRol(rol);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post(Usuario us)
        {
            con.AddUsuario(us);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public void Put(Usuario us)
        {
            con.UpdateUsuario(us);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            con.DeleteUsuario(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void AddPasaje(Pasaje pa, int id)
        {
            con.AddPasaje(pa,id);
        }

        
        [HttpGet]
        [Route("Conductores")]
        public List<Usuario> GetConductores()
        {
            return con.GetConductores();
        }
    }
}
