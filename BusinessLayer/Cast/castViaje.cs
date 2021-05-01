using BusinessLayer.cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cast
{
 public static class castViaje
    {
       public static Share.Entities.Viaje cast( DataAccesLayer.Entities.Viaje pa)
        {
            if (pa != null)
            {
                Share.Entities.Viaje p = new Share.Entities.Viaje()
                {
                    pasajes = castPasaje.castList(pa.pasajes),
                    asientos = castAsiento.castList(pa.asientos),
                    DiasViaje = castDia.castList(pa.DiasViaje),
                    estado = pa.estado,
                    fechaFinal = (DateTime)pa.fechaFinal,
                    fechaInicial = (DateTime)pa.fechaInicial,
                    idViaje = pa.idViaje,
                    horario = castHorario.cast(pa.horario),
                    localizacion = castLocalizacion.cast(pa.localizacion)

                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static DataAccesLayer.Entities.Viaje cast(Share.Entities.Viaje pa)
        {
            if (pa != null)
            {
                DataAccesLayer.Entities.Viaje p = new DataAccesLayer.Entities.Viaje()
                {
                    pasajes = castPasaje.castList(pa.pasajes),
                    asientos = castAsiento.castList(pa.asientos),
                    DiasViaje = castDia.castList(pa.DiasViaje),
                    estado = pa.estado,
                    fechaFinal = pa.fechaFinal,
                    fechaInicial = pa.fechaInicial,
                    idViaje = pa.idViaje,
                    horario = castHorario.cast(pa.horario),
                    localizacion = castLocalizacion.cast(pa.localizacion)
                };
                return p;
            }
            else
            {
                return null;
            }
        }

        public static List<DataAccesLayer.Entities.Viaje> castList(List<Share.Entities.Viaje> pa)
        {
            List<DataAccesLayer.Entities.Viaje> ret = new List<DataAccesLayer.Entities.Viaje>();
            if (pa != null)
            {
                foreach (Share.Entities.Viaje el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

        public static List<Share.Entities.Viaje> castList(List<DataAccesLayer.Entities.Viaje> pa)
        {
            List<Share.Entities.Viaje> ret = new List<Share.Entities.Viaje>();
            if (pa != null)
            {
                foreach (DataAccesLayer.Entities.Viaje el in pa)
                {
                    ret.Add(cast(el));
                }
            }
            return ret;
        }

    }
}
