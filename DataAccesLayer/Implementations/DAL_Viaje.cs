using DataAccesLayer.Entities;
using DataAccesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace DataAccesLayer.Implementations
{
    public class DAL_Viaje : IDAL_Viaje
    {
        public void DeleteViaje(int id)
        {
            try
            {
                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.Find(id);
                DB.Viaje.Remove(vi);
                DB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public Viaje GetViaje(int Id)
        {
            try
            {
                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.Include("localizacion").Include("horario.linea.Parada.Parada").Include("horario.linea.ParadaAnterior").FirstOrDefault(v => v.idViaje == Id);
                return vi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Viaje> GetViajes()
        {
            try
            {

                var DB = new Context.AppContext();

                return DB.Viaje.Include("localizacion").ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Viaje UpdateViaje(Viaje vi)
        {
            try
            {
                var DB = new Context.AppContext();
                Viaje v = DB.Viaje.FirstOrDefault(x => x.idViaje == vi.idViaje);
                v.estado = vi.estado;
                v.fechaFinal = vi.fechaFinal;
                v.fechaInicial = vi.fechaInicial;
                DB.SaveChanges();
                return vi;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Pasaje AddPasaje(Pasaje pa, int idViaje,int idusuario,int idAsiento)
        {
            try
            {

                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.FirstOrDefault(v => v.idViaje == idViaje);
                Usuario us = DB.Usuario.FirstOrDefault(u => u.idUsuario == idusuario);
                if (vi != null)
                {
                    DB.Pasaje.Add(pa);
                    DB.SaveChanges();
                    pa.usuario = us;
                    pa.viaje = vi;
                    if (idAsiento != 0)
                    {
                        Asiento asi = DB.Asiento.FirstOrDefault(a => a.idAsiento == idAsiento);
                        pa.asiento = asi;
                    }
                }
                DB.SaveChanges();
                return pa;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Pasaje AddPasajePlatafoma(Pasaje pa, int idViaje, int idAsiento)
        {
            try
            {

                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.FirstOrDefault(v => v.idViaje == idViaje);
               
                if (vi != null)
                {
                    DB.Pasaje.Add(pa);
                    DB.SaveChanges();
                    pa.viaje = vi;
                    if (idAsiento != 0)
                    {
                        Asiento asi = DB.Asiento.FirstOrDefault(a => a.idAsiento == idAsiento);
                        pa.asiento = asi;
                    }
                   
                }
                DB.SaveChanges();
                return pa;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Asiento AddAsiento(Asiento a, int idViaje)
        {
            try
            {

                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.FirstOrDefault(v => v.idViaje == idViaje);
                if (vi != null)
                {
                    vi.asientos.Add(a);
                }
                DB.SaveChanges();
                return a;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Dia AddDia(Dia di, int idViaje)
        {
            try
            {
                var DB = new Context.AppContext();
                Viaje vi = DB.Viaje.FirstOrDefault(v => v.idViaje == idViaje);
                if (vi != null)
                {
                    vi.DiasViaje.Add(di);
                }
                DB.SaveChanges();
                return di;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Viaje AddViaje(Share.Entities.DtoViaje vi ,List<Dia> dias,int cantidad)
        {
            try
            {
                var DB = new Context.AppContext();
                Viaje viaje = new Viaje()
                {
                    estado = false,
                    fechaInicial = vi.fechaInicial,
                    fechaFinal = vi.fechaFinal
                };
              //  DB.Viaje.Add(viaje);
                for (int i = 1; i <= cantidad; i++)
                {
                    Asiento asiento = new Asiento()
                    {
                        disponible = true,
                        nroAsiento = i
                    };
                    viaje.asientos.Add(asiento);

                }

                Localizacion localizacion = new Localizacion()
                {
                    HoraDeLlegada = Convert.ToDateTime("2019-01-06T07:16:40"),
                    ultimaPosicion = 0
                };

                foreach (Dia dia in dias)
                {
                    Dia d = DB.Dia.FirstOrDefault(z => z.idDia == dia.idDia);
                    viaje.DiasViaje.Add(d);
                }

                viaje.localizacion = localizacion;
               
                Horario horario = DB.Horario.FirstOrDefault(x => x.idHorario == vi.idHorario);

                DB.Viaje.Add(viaje);
                horario.viaje = viaje;
             
                DB.SaveChanges();
                horario.idViaje = viaje.idViaje;
                DB.SaveChanges();
                return viaje;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Viaje> ViajesChofer(int id)
        {
            var DB = new Context.AppContext();
          List<Horario> horarios =  DB.Horario.Include("Viaje").Where(x => x.idUsuario == id).ToList();
           List<Viaje> viajes =new List<Viaje>();
            foreach(Horario or in horarios)
            {
                if (or.viaje != null)
                {
                    viajes.Add(or.viaje);
                }
            }

            return viajes;
        }

        public void comensarViaje(int id ,DateTime hora){
            var DB = new Context.AppContext();
            Viaje vi = DB.Viaje.Include("localizacion").FirstOrDefault(x => x.idViaje == id);
            vi.estado = true;
            vi.localizacion.HoraDeLlegada = hora;
            vi.localizacion.ultimaPosicion = 1;
            DB.SaveChanges();
        }

        public List<Viaje> ViajePasaje(Share.Entities.DtoViajePasaje dto,string di)
        {
            var DB = new Context.AppContext();
            Dia dia = DB.Dia.First(d => d.nombre == di);
            Parada ori = DB.Parada.FirstOrDefault(x => x.idParada == dto.origen);
            Parada fin = DB.Parada.FirstOrDefault(x => x.idParada == dto.fin);
            List<Viaje> ret = DB.Viaje.Include("horario.linea.paradaAnterior.precios").Include("horario.linea.parada").Include("localizacion").Where(x => x.DiasViaje.Any(d => d.nombre == di)).Where(x => x.horario.linea.Parada.Any(o => o.Parada.idParada == dto.origen)).Where(x => x.horario.linea.Parada.Any(o => o.Parada.idParada == dto.fin)).ToList();
            return ret;
        }

        public Viaje validarPasaje(Share.Entities.DtoValidar dto)
        {
            var DB = new Context.AppContext();
            return DB.Viaje.Include("localizacion").Where(x => x.pasajes.Any(o => o.codigo == dto.qr)).FirstOrDefault();
        }

        public List<Viaje> ViajesEnCurso()
        {
            var DB = new Context.AppContext();
            return DB.Viaje.Include("horario.linea.Parada.Parada").Include("localizacion").Where(v => v.estado == true).ToList();
        }

        public void FinalizarViaje(int id)
        {
            var DB = new Context.AppContext();
            Viaje vi = DB.Viaje.Include("localizacion").Where(v => v.idViaje == id).FirstOrDefault();
            vi.localizacion.ultimaPosicion = 0;
            vi.estado = false;
            DB.SaveChanges();
        }

        public void MoverVehiculo(int id ,DateTime hora)
        {
            var DB = new Context.AppContext();
            Viaje vi = DB.Viaje.Include("localizacion").Where(v => v.idViaje == id).FirstOrDefault();
            vi.localizacion.ultimaPosicion = vi.localizacion.ultimaPosicion+1;
            vi.localizacion.HoraDeLlegada = hora;
            DB.SaveChanges();
        }

        public List<Viaje> ProximoVehiculo(int id)
        {
            var DB = new Context.AppContext();
           return  DB.Viaje.Include("horario.linea").Include("pasajes").Where(x => x.estado == true).Where(x => x.horario.linea.Parada.Any(o => (o.Parada.idParada == id) && (o.posicion == x.localizacion.ultimaPosicion+1))).ToList();
        }


        //FUNCIONES PARA REPORTES

        public List<Pasaje> soloPasajes(DateTime f1,DateTime f2)
        {
            var DB = new Context.AppContext();
            return DB.Pasaje.Where(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day))).ToList();
        }

        public List<Linea> lineasConPasajes(DateTime f1, DateTime f2)
        {
            var DB = new Context.AppContext();
            return DB.Linea.Where(l => l.Horarios.Any(h => h.viaje.pasajes.Any(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day))))).ToList();
        }
        public List<Pasaje> pasajesporLinea(DateTime f1, DateTime f2, int idlinea) 
        {
            var DB = new Context.AppContext();
            return DB.Pasaje.Where(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day))).Where(p => p.viaje.horario.linea.idLinea == idlinea).ToList();
        }
        public List<Horario> horarioConPasajes(DateTime f1, DateTime f2) 
        {
            var DB = new Context.AppContext();
            return DB.Horario.Where(h => h.viaje.pasajes.Any(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day)))).ToList();
        }
        public List<Pasaje> pasajesporHorario(DateTime f1, DateTime f2, DateTime fecha)
        {
            var DB = new Context.AppContext();
            return DB.Pasaje.Where(p => ((p.fecha.Year <= f2.Year) &&(p.fecha.Month <= f2.Month) &&(p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) &&(p.fecha.Month >= f1.Month) &&(p.fecha.Day >= f1.Day))).Where(p => (p.viaje.horario.hora.Hour == fecha.Hour)&&(p.viaje.horario.hora.Minute == fecha.Minute) &&(p.viaje.horario.hora.Second == fecha.Second) ).ToList();
        }
        //PORSENTAJES
        public List<Viaje> viajesConPasajes(DateTime f1, DateTime f2)
        {
            var DB = new Context.AppContext();
            return DB.Viaje.Include("horario.vehiculo").Include("horario.linea.paradaAnterior.precios").Include("pasajes").Where(v => v.pasajes.Any(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day)))).ToList();
        }

        public List<Pasaje> pasajesPorViaje(DateTime f1, DateTime f2,int idViaje)
        {
            var DB = new Context.AppContext();
            return DB.Pasaje.Where(p => ((p.fecha.Year <= f2.Year) && (p.fecha.Month <= f2.Month) && (p.fecha.Day <= f2.Day)) && ((p.fecha.Year >= f1.Year) && (p.fecha.Month >= f1.Month) && (p.fecha.Day >= f1.Day))).Where(p => p.viaje.idViaje == idViaje).ToList();
        }
    }
}
