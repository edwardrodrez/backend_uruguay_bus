


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.cast
{
    public static class castVehiculo
    {
        public static DataAccesLayer.Entities.Vehiculo cast(Share.Entities.Vehiculo v) {
            if (v != null)
            {
                DataAccesLayer.Entities.Vehiculo ret = new DataAccesLayer.Entities.Vehiculo();
                ret.cantAsientos = v.cantAsientos;
                ret.marca = v.marca;
                ret.matricula = v.matricula;
                ret.modelo = v.modelo;
                ret.idVehiculo = v.idVehiculo;
                ret.horarios = null;//castHorario.castList(v.horarios);
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static Share.Entities.Vehiculo cast(DataAccesLayer.Entities.Vehiculo v)
        {
            if (v != null)
            {
                Share.Entities.Vehiculo ret = new Share.Entities.Vehiculo();
                ret.cantAsientos = v.cantAsientos;
                ret.marca = v.marca;
                ret.matricula = v.matricula;
                ret.modelo = v.modelo;
                ret.idVehiculo = v.idVehiculo;
                ret.horarios = null;//castHorario.castList(v.horarios);
                return ret;
            }
            else
            {
                return null;
            }
        }

        public static List<Share.Entities.Vehiculo> castList(List<DataAccesLayer.Entities.Vehiculo> v)
        {
            List<Share.Entities.Vehiculo> l = new List<Share.Entities.Vehiculo>();
            if (v != null)
            {
                foreach (DataAccesLayer.Entities.Vehiculo e in v)
                {
                    l.Add(cast(e));
                }
            }
            return l;
        }

        public static List<DataAccesLayer.Entities.Vehiculo> castList(List<Share.Entities.Vehiculo> v)
        {
            List<DataAccesLayer.Entities.Vehiculo> l = new List<DataAccesLayer.Entities.Vehiculo>();
            if (v != null)
            {
                foreach (Share.Entities.Vehiculo e in v)
                {
                    l.Add(castVehiculo.cast(e));
                }
            }
            return l;
        }
    }
}
