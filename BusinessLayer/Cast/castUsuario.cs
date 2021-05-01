using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.cast;

namespace BusinessLayer.Cast
{
 public static class castUsuario
    {
       public static Share.Entities.Usuario cast( DataAccesLayer.Entities.Usuario pa)
        {
            if (pa != null)
            {
                if (pa.rol == "Conductor") {
                    Share.Entities.Usuario p = new Share.Entities.Usuario()
                    {
                        apellido = pa.apellido,
                        correo = pa.correo,
                        rol = pa.rol,
                        fechaLibreta = (DateTime)pa.fechaLibreta,
                        horarios = null,
                        idUsuario = pa.idUsuario,
                        nombre = pa.nombre,
                        Token = pa.Token,
                        pasajes = castPasaje.castList(pa.pasajes),
                        password = null
                    };
                    return p;
                }
                else
                {
                    Share.Entities.Usuario p = new Share.Entities.Usuario()
                    {
                        apellido = pa.apellido,
                        correo = pa.correo,
                        rol = pa.rol,
                        horarios = null,
                        idUsuario = pa.idUsuario,
                        nombre = pa.nombre,
                        Token = pa.Token,
                        pasajes = castPasaje.castList(pa.pasajes),
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

        public static DataAccesLayer.Entities.Usuario cast(Share.Entities.Usuario pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.Usuario p = new DataAccesLayer.Entities.Usuario()
                {
                    apellido = pa.apellido,
                    correo = pa.correo,
                    fechaLibreta = pa.fechaLibreta,
                    horarios = null,//castHorario.castList(pa.horarios),
                    idUsuario = pa.idUsuario,
                    nombre = pa.nombre,
                    Token = pa.Token,
                    pasajes = castPasaje.castList(pa.pasajes),
                    password = pa.password
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.Usuario> castList(List<Share.Entities.Usuario> pa)
        {
            List<DataAccesLayer.Entities.Usuario> ret = new List<DataAccesLayer.Entities.Usuario>();
            if (pa != null)
            {
                foreach (Share.Entities.Usuario el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Usuario> castList(List<DataAccesLayer.Entities.Usuario> pa)
        {
            List<Share.Entities.Usuario> ret = new List<Share.Entities.Usuario>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Usuario el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
