using DataAccesLayer.Entities;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_ParadaAnterior
    {
        ParadaAnterior AddParadaAnterior(ParadaAnterior para);

        void AddPrecio(int id, Precios pr);
        void AddLinea(int id, int idl);

    }
}
