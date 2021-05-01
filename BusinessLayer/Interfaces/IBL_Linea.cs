using Share.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Linea
    {
        List<Linea> GetLinea();

        Linea GetLinea(int Id);

        Linea AddLinea(Linea Linea);

        Linea UpdateLinea(Linea Linea);

        void DeleteLinea(int Id);

        ParadaAnterior AddParadaAnterior(ParadaAnterior paradaAnterior, int IdLinea);
        Parada_linea AddParada_linea(int IdParada_linea, int IdLinea);
        Horario AddHorario(int IdHorario, int IdLinea);

        void DeleteParadaAnterior(int IdParadaAnterior);
        void DeleteParada_linea(int IdParada_linea);
        void DeleteHorario(int IdHorario, int IdLinea);

        List<Parada> GetParadas(int id);

        void AddParada(DTOaddParada dt);

        Parada GetUltimaParada(int id);

        ParadaAnterior GetParadaAnterior(int id);

        void AddPrecio(DtoPrecio dt);
    }
}
