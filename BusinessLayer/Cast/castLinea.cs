using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cast;

namespace BusinessLayer.cast
{
    public static class castLinea
    {
        public static DataAccesLayer.Entities.Linea cast(Share.Entities.Linea v) {
            if (v != null)
            {
                DataAccesLayer.Entities.Linea ret = new DataAccesLayer.Entities.Linea()
                {
                    idLinea = v.idLinea,
                    nombre = v.nombre,
                    ParadaAnterior = castParadaAnterior.castList(v.ParadaAnterior),
                    Parada = castParada_linea.castList(v.Parada),
                    Horarios = null//castHorario.castList(v.Horarios)
                };
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Linea cast(DataAccesLayer.Entities.Linea v)
        {
            if (v != null)
            {
                Share.Entities.Linea ret = new Share.Entities.Linea()
                {
                    idLinea = v.idLinea,
                    nombre = v.nombre,
                    ParadaAnterior = castParadaAnterior.castList(v.ParadaAnterior),
                    Parada = castParada_linea.castList(v.Parada),
                    Horarios = null//castHorario.castList(v.Horarios)
                };
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Linea> castList(List<DataAccesLayer.Entities.Linea> v)
        {
            List<Share.Entities.Linea> l = new List<Share.Entities.Linea>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Linea e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Linea> castList(List<Share.Entities.Linea> v)
        {
            List<DataAccesLayer.Entities.Linea> l = new List<DataAccesLayer.Entities.Linea>();
            if (v != null)
            {
                foreach (Share.Entities.Linea e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }
    }
}
