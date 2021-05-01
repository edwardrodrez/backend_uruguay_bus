
using DataAccesLayer.Entities;
using System.Collections.Generic;

namespace DataAccesLayer.Interfaces
{
    public interface IDAL_Linea
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

        List<Parada_linea> GetParadas(int id);

        ParadaAnterior GetParadaAnterior(int id);

        void AddPrecio(Precios p,int id);

    }
}
