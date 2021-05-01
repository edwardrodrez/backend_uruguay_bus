using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cast;

namespace BusinessLayer.cast
{
    public static class castHorario
    {
        public static DataAccesLayer.Entities.Horario cast(Share.Entities.Horario v) {
            if (v != null)
            {
                DataAccesLayer.Entities.Horario ret = new DataAccesLayer.Entities.Horario()
                {
                    idHorario = v.idHorario,
                    hora = v.hora,
                    linea = castLinea.cast(v.linea),
                    vehiculo = castVehiculo.cast(v.vehiculo),
                    usuario = castUsuario.cast(v.usuario)
                };

                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Horario cast(DataAccesLayer.Entities.Horario v)
        {
            if (v != null)
            {
                Share.Entities.Horario ret = new Share.Entities.Horario()
                {
                    idHorario = v.idHorario,
                     hora = (DateTime)v.hora,
                    linea = castLinea.cast(v.linea),
                    vehiculo = castVehiculo.cast(v.vehiculo),
                    usuario = castUsuario.cast(v.usuario)
                };

                if (v.viaje != null)
                {
                    ret.Viaje = true;
                }
                else
                ret.Viaje = false;

                return ret;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Horario> castList(List<DataAccesLayer.Entities.Horario> v)
        {
            List<Share.Entities.Horario> l = new List<Share.Entities.Horario>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Horario e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Horario> castList(List<Share.Entities.Horario> v)
        {
            List<DataAccesLayer.Entities.Horario> l = new List<DataAccesLayer.Entities.Horario>();
            if (v != null)
            {
                foreach (Share.Entities.Horario e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }
    }
}
