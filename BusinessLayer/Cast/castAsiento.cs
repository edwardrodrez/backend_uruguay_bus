using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cast;

namespace BusinessLayer.Cast
{
    public static class castAsiento
    {
        public static DataAccesLayer.Entities.Asiento cast(Share.Entities.Asiento v) {
            if (v != null)
            {
                DataAccesLayer.Entities.Asiento ret = new DataAccesLayer.Entities.Asiento()
                {
                    idAsiento = v.idAsiento,
                    disponible = v.disponible,
                    nroAsiento = v.nroAsiento,
                    pasajes = castPasaje.castList(v.pasajes)
                };
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Asiento cast(DataAccesLayer.Entities.Asiento v)
        {
            if (v != null)
            {
                Share.Entities.Asiento ret = new Share.Entities.Asiento()
                {
                    idAsiento = v.idAsiento,
                    disponible = v.disponible,
                    nroAsiento = (int)v.nroAsiento,
                    pasajes = castPasaje.castList(v.pasajes)
                };
                return ret;
            }
            else
            {
                return null;
            }

        }

        public static List<Share.Entities.Asiento> castList(List<DataAccesLayer.Entities.Asiento> v)
        {
            List<Share.Entities.Asiento> l = new List<Share.Entities.Asiento>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Asiento e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Asiento> castList(List<Share.Entities.Asiento> v)
        {
            List<DataAccesLayer.Entities.Asiento> l = new List<DataAccesLayer.Entities.Asiento>();
            if (v != null)
            {
                foreach (Share.Entities.Asiento e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }
    }
}
