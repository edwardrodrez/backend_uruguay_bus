using BusinessLayer.cast;
using BusinessLayer.Interfaces;
using Share.Entities;
using DataAccesLayer.Interfaces;
using System.Collections.Generic;
using BusinessLayer.Cast;
using System.Runtime.InteropServices;
using System;
using System.Dynamic;

namespace DataAccesLayer.Implementations
{
    public class BL_Linea : IBL_Linea
    {
        private IDAL_Linea dal = new DAL_Linea();
        private IDAL_Precios dalpr = new DAL_Precios();
        private IDAL_Parada dalp = new DAL_Parada();
        private IDAL_Parada_Linea dalpl = new DAL_Parada_Linea();
        private IDAL_ParadaAnterior dalpa = new DAL_ParadaAnterior();


        public void DeleteParadaAnterior(int IdParadaAnterior)
        {
            dal.DeleteParadaAnterior(IdParadaAnterior);    
        }

        public void DeleteParada_linea(int IdParada_linea)
        {
            dal.DeleteParada_linea(IdParada_linea);    
        }

        public void DeleteHorario(int IdHorario, int IdLinea)
        {
            dal.DeleteHorario(IdHorario, IdLinea);
        }

        public void DeleteLinea(int Id)
        {
            dal.DeleteLinea(Id);
        }

        public Linea GetLinea(int Id)
        {
            return castLinea.cast(dal.GetLinea(Id));
        }

        public List<Linea> GetLinea()
        {
            return castLinea.castList(dal.GetLinea());
        }

        public Linea UpdateLinea(Linea Linea)
        {
            return castLinea.cast(dal.UpdateLinea(castLinea.cast(Linea)));
        }

        public ParadaAnterior AddParadaAnterior(ParadaAnterior ParadaAnterior, int idLinea)
        {
            return castParadaAnterior.cast(dal.AddParadaAnterior(castParadaAnterior.cast(ParadaAnterior),idLinea));
        }

        public Parada_linea AddParada_linea(int IdParada_linea, int idLinea)
        {
            return castParada_linea.cast(dal.AddParada_linea(IdParada_linea, idLinea));
        }

        public Horario AddHorario(int IdHorario, int IdLinea)
        {
            return castHorario.cast(dal.AddHorario(IdHorario, IdLinea));
        }

        public Linea AddLinea(Linea Linea)
        {
          return  castLinea.cast(dal.AddLinea(castLinea.cast(Linea)));
        }

        public List<Parada> GetParadas(int id)
        {
             
        List<Parada_linea> lis = castParada_linea.castList(dal.GetParadas(id));
            List<Parada> ret = new List<Parada>();   
            foreach(Parada_linea par in lis)
            {
                ret.Add(par.Parada);
            }
            return ret;
        }


        public void AddParada(DTOaddParada dt)
        {
             
            int pos = 0;
            List<Parada_linea> lis = castParada_linea.castList(dal.GetParadas(dt.idlinea));
            foreach(Parada_linea par in lis)
            {
                if(par.posicion > pos)
                {
                    pos = par.posicion;
                }
            }
            pos++;



            Parada_linea pl = new Parada_linea()
            {
                posicion = pos
            };
            Parada_linea ret = castParada_linea.cast(dalpl.AddParada_Linea(castParada_linea.cast(pl)));
            dalpl.AddLinea(ret.idParada_linea, dt.idlinea);
            dalpl.AddParada(ret.idParada_linea, dt.idParada);



            Precios pre = new Precios()
            {
                FechaCaducidad = Convert.ToDateTime(dt.fechacaducidad),
                precio = dt.precio
            };



            ParadaAnterior parad = new ParadaAnterior()
            {
                posicion = pos,
                tiempo = Convert.ToDateTime(dt.tiempo),
                Precios = new List<Precios>()
            };
            ParadaAnterior pa = castParadaAnterior.cast(dalpa.AddParadaAnterior(castParadaAnterior.cast(parad)));
            dalpa.AddPrecio(pa.idAnterior,castPrecios.cast(pre));
            dalpa.AddLinea(pa.idAnterior, dt.idlinea);
            

        }

        public Parada GetUltimaParada(int id)
        {
            List<Parada_linea> lis = castParada_linea.castList(dal.GetParadas(id));
            Parada ret = null;
            int pos = 0;
            foreach(Parada_linea pa in lis)
            {
                if(pa.posicion > pos)
                {
                    ret = pa.Parada;
                    pos = pa.posicion;
                }
            }
            return ret;
        }

       public ParadaAnterior GetParadaAnterior(int id)
        {
            return castParadaAnterior.cast(dal.GetParadaAnterior(id));
        }

        public void AddPrecio(DtoPrecio dt)
        {
            Precios pre = new Precios()
            {
                FechaCaducidad = Convert.ToDateTime(dt.FechaCaducidad),
                precio = dt.precio
            };

            dal.AddPrecio(castPrecios.cast(pre),dt.idparadaAnterior);
        }
    }


  
}
