using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cast
{
 public static class castDia
    {
       public static Share.Entities.Dia cast( DataAccesLayer.Entities.Dia pa)
        {
            if (pa != null)
            {
                Share.Entities.Dia p = new Share.Entities.Dia()
                {
                    idDia = pa.idDia,
                   nombre = pa.nombre
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static DataAccesLayer.Entities.Dia cast(Share.Entities.Dia pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.Dia p = new DataAccesLayer.Entities.Dia()
                {
                    idDia = pa.idDia,
                    nombre = pa.nombre
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.Dia> castList(List<Share.Entities.Dia> pa)
        {
            List<DataAccesLayer.Entities.Dia> ret = new List<DataAccesLayer.Entities.Dia>();
            if (pa != null)
            {
                foreach (Share.Entities.Dia el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Dia> castList(List<DataAccesLayer.Entities.Dia> pa)
        {
            List<Share.Entities.Dia> ret = new List<Share.Entities.Dia>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Dia el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
