using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccesLayer.Implementations
{
    public class DAL_Usuario : IDAL_Usuario
    {
        public void DeleteUsuario(int id)
        {
            try
            {
                var DB = new Context.AppContext();
                Usuario us = DB.Usuario.Find(id);
                DB.Usuario.Remove(us);
                DB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Usuario GetUsuario(int Id)
        {
            try
            {
                var DB = new Context.AppContext();
                return DB.Usuario.Include("pasajes").FirstOrDefault(p => p.idUsuario == Id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarRol(Share.Entities.DtoRoles rol) {

            var DB = new Context.AppContext();
            Usuario us = DB.Usuario.FirstOrDefault(x => x.idUsuario == rol.idusuario);
            if(rol.rol == "Conductor")
            {
                us.rol = rol.rol;
                us.fechaLibreta = rol.fechaLibreta;
            }
            else
            {
                us.rol = rol.rol;
            }
            DB.SaveChanges();
        }

        public Usuario GetUsuarioPorCorreo(string correo)
        {

            
            var DB = new Context.AppContext();
                return DB.Usuario.Where(x => x.correo == correo).FirstOrDefault();
            
           
        }

        public Usuario login(string correo,string pass)
        {

            var DB = new Context.AppContext();
            Usuario u = DB.Usuario.Where(x => x.correo == correo).FirstOrDefault();
            if (u == null) {
                return null;
            }
            PasswordHasher h = new PasswordHasher();
            if (h.VerifyHashedPassword(u.password , pass) != PasswordVerificationResult.Failed)
            {
                return u;
            }
            return null;

        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                var DB = new Context.AppContext();
                return DB.Usuario.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario UpdateUsuario(Usuario us)
        {
            try
            {
                var DB = new Context.AppContext();
                Usuario u = DB.Usuario.FirstOrDefault(x => x.idUsuario == us.idUsuario);
                u.nombre = us.nombre;
                u.apellido = us.apellido;
                u.correo = us.correo;
                u.Token = us.Token;
                DB.SaveChanges();
                return us;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Pasaje AddPasaje(Pasaje pa, int id)
        {
            try
            {

                var DB = new Context.AppContext();
                Usuario us = DB.Usuario.FirstOrDefault(x => x.idUsuario == id);
                if (us != null)
                {
                    us.pasajes.Add(pa);
                }
                DB.SaveChanges();
                return pa;


            }
            catch (Exception)
            {
                throw;
            }

        }
        public Usuario AddUsuario(Usuario us)
        {
            try
            {
                us.rol = "User";
                var DB = new Context.AppContext();
                us.rol = "User";
                DB.Usuario.Add(us);
                DB.SaveChanges();
                return us;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Usuario> GetConductores()
        {
            try
            {
                var DB = new Context.AppContext();
                return DB.Usuario.Where(u => u.rol == "Conductor").ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
