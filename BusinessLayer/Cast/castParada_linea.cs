using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cast;

namespace BusinessLayer.cast
{
    public static class castParada_linea
    {
        public static DataAccesLayer.Entities.Parada_linea cast(Share.Entities.Parada_linea v) 
        {
            if (v != null)
            {
                DataAccesLayer.Entities.Parada_linea ret = new DataAccesLayer.Entities.Parada_linea()
                {

                    idParada_linea = v.idParada_linea,
                    posicion = v.posicion,
                    Parada = castParada.cast(v.Parada),
                    Linea = null,//castLinea.cast(v.Linea)

                };

                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Parada_linea cast(DataAccesLayer.Entities.Parada_linea v)
        {
            if (v != null)
            {
                Share.Entities.Parada_linea ret = new Share.Entities.Parada_linea()
                {
                    idParada_linea = v.idParada_linea,
                    posicion = v.posicion,
                    Parada = castParada.cast(v.Parada),
                    Linea =null,// castLinea.cast(v.Linea)
                };

                return ret;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Parada_linea> castList(List<DataAccesLayer.Entities.Parada_linea> v)
        {
            List<Share.Entities.Parada_linea> l = new List<Share.Entities.Parada_linea>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Parada_linea e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Parada_linea> castList(List<Share.Entities.Parada_linea> v)
        {
            List<DataAccesLayer.Entities.Parada_linea> l = new List<DataAccesLayer.Entities.Parada_linea>();
            if (v != null)
            {
                foreach (Share.Entities.Parada_linea e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }
    }
}
