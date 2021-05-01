using Share.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Parada
    {
        List<Parada> GetParadas();

        Parada GetParada(int Id);

        Parada AddParada(Parada para);

        Parada UpdateParada(Parada para);

        void DeleteParada(int Id);

        Parada_linea AddParada_linea(Parada_linea pl, int idParada);

    }
}
