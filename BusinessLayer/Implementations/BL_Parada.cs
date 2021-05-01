using BusinessLayer.Cast;
using Share.Entities;
using DataAccesLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Interfaces;
using BusinessLayer.cast;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Parada : IBL_Parada
    {
        private IDAL_Parada dal = new DAL_Parada();

       
        public void DeleteParada(int idParada)
        {
            try
            {
                dal.DeleteParada(idParada);
            }
            catch (Exception)
            {
                throw ;
            }
        }
        public Parada GetParada(int Id)
        {
            try
            {
                return castParada.cast(dal.GetParada(Id));
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Parada> GetParadas()
        {
            try
            {

                return castParada.castList(dal.GetParadas());

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Parada UpdateParada(Parada para)
        {
            try
            {
                return castParada.cast(dal.UpdateParada(castParada.cast(para)));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Parada_linea AddParada_linea(Parada_linea pl, int idParada)
        {
            try
            {
                return castParada_linea.cast(dal.AddParada_linea(castParada_linea.cast(pl), idParada));
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Parada AddParada(Parada para)
        {
            try
            {
                return castParada.cast(dal.AddParada(castParada.cast(para)));
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
