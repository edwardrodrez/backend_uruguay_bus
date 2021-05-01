using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cast;

namespace BusinessLayer.cast
{
    public static class castLocalizacion
    {
        public static DataAccesLayer.Entities.Localizacion cast(Share.Entities.Localizacion v) {
            if (v != null)
            {
                DataAccesLayer.Entities.Localizacion ret = new DataAccesLayer.Entities.Localizacion()
                {   
                    idlocalizacion = v.idlocalizacion,
                    ultimaPosicion = v.ultimaPosicion,
                    HoraDeLlegada = v.HoraDeLlegada
                };
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Localizacion cast(DataAccesLayer.Entities.Localizacion v)
        {
            if (v != null)
            {
                Share.Entities.Localizacion ret = new Share.Entities.Localizacion()
                {
                    idlocalizacion = v.idlocalizacion,
                    ultimaPosicion = (int)v.ultimaPosicion,
                    HoraDeLlegada = v.HoraDeLlegada
                };
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Localizacion> castList(List<DataAccesLayer.Entities.Localizacion> v)
        {
            List<Share.Entities.Localizacion> l = new List<Share.Entities.Localizacion>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Localizacion e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Localizacion> castList(List<Share.Entities.Localizacion> v)
        {
            List<DataAccesLayer.Entities.Localizacion> l = new List<DataAccesLayer.Entities.Localizacion>();
            if (v != null)
            {
                foreach (Share.Entities.Localizacion e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }
    }
}
