using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.cast;

namespace BusinessLayer.Cast
{
    public static class castParadaAnterior
    {

        public static Share.Entities.ParadaAnterior cast(DataAccesLayer.Entities.ParadaAnterior pa)
        {
            if (pa != null)
            {
                Share.Entities.ParadaAnterior p = new Share.Entities.ParadaAnterior()
                {
                    idAnterior = pa.idAnterior,
                    linea = null,
                    posicion = pa.posicion,
                    Precios = castPrecios.castList(pa.Precios),
                    tiempo = pa.tiempo
                };
                return p;
            }
            else
            {
                return null;
            }
        }
        public static DataAccesLayer.Entities.ParadaAnterior cast(Share.Entities.ParadaAnterior pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.ParadaAnterior p = new DataAccesLayer.Entities.ParadaAnterior()
                {
                    idAnterior = pa.idAnterior,
                    linea = null,
                    posicion = pa.posicion,
                    Precios = castPrecios.castList(pa.Precios),
                    tiempo = pa.tiempo
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.ParadaAnterior> castList(List<Share.Entities.ParadaAnterior> pa)
        {
            List<DataAccesLayer.Entities.ParadaAnterior> ret = new List<DataAccesLayer.Entities.ParadaAnterior>();
            if (pa != null)
            {
                foreach (Share.Entities.ParadaAnterior el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.ParadaAnterior> castList(List<DataAccesLayer.Entities.ParadaAnterior> pa)
        {
            List<Share.Entities.ParadaAnterior> ret = new List<Share.Entities.ParadaAnterior>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.ParadaAnterior el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }
    }
}
