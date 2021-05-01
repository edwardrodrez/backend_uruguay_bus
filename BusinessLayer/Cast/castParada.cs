using BusinessLayer.cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cast
{
 public static class castParada
    {
       public static Share.Entities.Parada cast( DataAccesLayer.Entities.Parada parada)
        {
            if (parada != null)
            {
                Share.Entities.Parada p = new Share.Entities.Parada()
                {
                    geoReferencia = parada.geoReferencia,
                    idParada = parada.idParada,
                    Linea = null,
                    nombre = parada.nombre
                };
                return p;
            }
            else
            {
                return null;
            }
        }
        public static DataAccesLayer.Entities.Parada cast(Share.Entities.Parada parada)
        {
            if (parada != null)
            {
                DataAccesLayer.Entities.Parada p = new DataAccesLayer.Entities.Parada()
                {
                    geoReferencia = parada.geoReferencia,
                    idParada = parada.idParada,
                    Linea = null,
                    nombre = parada.nombre
                };
                return p;
            }
            else
            {
                return null;

            }
        }
        public static List<DataAccesLayer.Entities.Parada> castList(List<Share.Entities.Parada> pa)
        {
            List<DataAccesLayer.Entities.Parada> ret = new List<DataAccesLayer.Entities.Parada>();
            if (pa != null)
            {
                foreach (Share.Entities.Parada el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Parada> castList(List<DataAccesLayer.Entities.Parada> pa)
        {
            List<Share.Entities.Parada> ret = new List<Share.Entities.Parada>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Parada el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
