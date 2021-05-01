using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cast
{
 public static class castPasaje
    {
       public static Share.Entities.Pasaje cast( DataAccesLayer.Entities.Pasaje pa)
        {
            if (pa != null)
            {
                Share.Entities.Pasaje p = new Share.Entities.Pasaje()
                {
                    fecha = pa.fecha,
                    idPasaje = pa.idPasaje,
                    nroDocumento = pa.nroDocumento,
                    posicionDestino = pa.posicionDestino,
                    posicionOrigen = pa.posicionOrigen,
                    TipoDocumento = pa.TipoDocumento,
                    nombreDestino = pa.nombreDestino,
                    nombreOrigen = pa.nombreOrigen,
                    codigo = pa.codigo,
                    precio = pa.precio,
                   

                };
                
                return p;
            }
            else
            {
                return null;
            }
        }

        public static DataAccesLayer.Entities.Pasaje cast(Share.Entities.Pasaje pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.Pasaje p = new DataAccesLayer.Entities.Pasaje()
                {
                    fecha = pa.fecha,
                    idPasaje = pa.idPasaje,
                    nroDocumento = pa.nroDocumento,
                    posicionDestino = pa.posicionDestino,
                    posicionOrigen = pa.posicionOrigen,
                    TipoDocumento = pa.TipoDocumento,
                    nombreDestino = pa.nombreDestino,
                    nombreOrigen = pa.nombreOrigen,
                    codigo = pa.codigo,
                    precio = pa.precio,
                    
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.Pasaje> castList(List<Share.Entities.Pasaje> pa)
        {
            List<DataAccesLayer.Entities.Pasaje> ret = new List<DataAccesLayer.Entities.Pasaje>();
            if (pa != null)
            {
                foreach (Share.Entities.Pasaje el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Pasaje> castList(List<DataAccesLayer.Entities.Pasaje> pa)
        {
            List<Share.Entities.Pasaje> ret = new List<Share.Entities.Pasaje>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Pasaje el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
