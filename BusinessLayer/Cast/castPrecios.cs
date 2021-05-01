using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cast
{
 public static class castPrecios
    {
       public static Share.Entities.Precios cast( DataAccesLayer.Entities.Precios pa)
        {
            if (pa != null)
            {
                Share.Entities.Precios p = new Share.Entities.Precios()
                {
                    idPrecio = pa.idPrecio,
                    FechaCaducidad = pa.FechaCaducidad,
                    ParadaAnterior = null,
                    precio = pa.precio
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static DataAccesLayer.Entities.Precios cast(Share.Entities.Precios pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.Precios p = new DataAccesLayer.Entities.Precios()
                {
                    idPrecio = pa.idPrecio,
                    FechaCaducidad = pa.FechaCaducidad,
                    ParadaAnterior = null,
                    precio = pa.precio
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.Precios> castList(List<Share.Entities.Precios> pa)
        {
            List<DataAccesLayer.Entities.Precios> ret = new List<DataAccesLayer.Entities.Precios>();
            if (pa != null)
            {
                foreach (Share.Entities.Precios el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Precios> castList(List<DataAccesLayer.Entities.Precios> pa)
        {
            List<Share.Entities.Precios> ret = new List<Share.Entities.Precios>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Precios el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
