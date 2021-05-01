using System;
using System.Collections.Generic;
using WEBAPI_CustomAuth.CustomIdentity;

namespace AppRest.Cast
{
 public static class castUser
    {
       public static User cast(Share.Entities.Usuario pa)
        {
            if (pa != null)
            {
                if (pa.rol == "Conductor") {
                    User p = new User()
                    {
                        apellido = pa.apellido,
                        UserName = pa.correo,
                        rol = pa.rol,
                        Id = pa.idUsuario.ToString(),
                        nombre = pa.nombre,
                        password = null
                    };
                    return p;
                }
                else
                {
                    User p = new User()
                    {
                        apellido = pa.apellido,
                        UserName = pa.correo,
                        rol = pa.rol,
                        Id = pa.idUsuario.ToString(),
                        nombre = pa.nombre,
                        password = null
                    };
                    return p;
                }
                
                
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Usuario cast(User pa)
        {
            if (pa != null)
            {
                Share.Entities.Usuario p = new Share.Entities.Usuario()

                {
                    apellido = pa.apellido,
                    correo = pa.UserName,
                    horarios = null,
                    nombre = pa.nombre,
                    password = pa.password
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Usuario> castList(List<User> pa)
        {
            List<Share.Entities.Usuario> ret = new List<Share.Entities.Usuario>();
            if (pa != null)
            {
                foreach (User el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<User> castList(List<Share.Entities.Usuario> pa)
        {
            List<User> ret = new List<User>();
            if (pa != null)
            {
                foreach (Share.Entities.Usuario el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
