using DataAccesLayer.Entities;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Precios
    {
        List<Precios> GetPrecios();

        Precios GetPrecio(int Id);

        Precios AddPrecio(Precios pre);

        Precios UpdatePrecio(Precios pre);

        void DeletePrecio(int Id);

       // Parada_linea AddParadaAnterior(ParadaAnterior pa, int idPrecio);

    }
}
