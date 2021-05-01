using BusinessLayer.Interfaces;
using DataAccesLayer.Implementations;

using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers
{
    [RoutePrefix("api/Linea")]
    public class LineaController : ApiController
    {
        // Post api/<LineaController>/5
        [HttpGet]
        [Route("ParadaAnterior/{id}")]
        public ParadaAnterior GetParadaAnterior(int id)
        {
            return con.GetParadaAnterior(id);
        }

        // DELETE api/<LineaController>/5
        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            con.DeleteLinea(id);
        }


        [Route("UltimaParada/{id}")]
        // GET: api/<LineaController>
        public Parada GetUltimaParada(int id)
        {
            return con.GetUltimaParada(id);
        }


        IBL_Linea con = new BL_Linea();
        // GET: api/<LineaController>
        [HttpGet]
        public List<Linea> Get()
        {
            return con.GetLinea();
        }

        // GET api/<LineaController>/5
        [HttpGet]
        [Route("ParadaAnterior/{id}")]
        public Linea Get(int id)
        {
            return con.GetLinea(id);
        }

        // POST api/<LineaController>
        [HttpPost]
        public Linea Post(Linea lin)
        {
           return con.AddLinea(lin);
        }

        // PUT api/<LineaController>/5
        [HttpPut]
        public Linea Put(Linea lin)
        {
            return con.UpdateLinea(lin);
        }

     

        // Post api/<LineaController>/5
        [HttpPost]
        [Route("ParadaAnterior")]
        public ParadaAnterior AddParadaAnterior(ParadaAnterior paradaAnterior, int id)
        {
           return con.AddParadaAnterior(paradaAnterior,id);
        }
       
        // PUT api/<LineaController>/5
        [HttpPut()]
        [Route("ParadaLinea")]
        public Parada_linea AddParadaLinea(int IdParada_linea, int id)
        {
            return con.AddParada_linea(IdParada_linea, id);
        }

       
        // PUT api/<LineaController>/5
        [HttpPut]
        [Route("Horario")]
        public Horario AddHorario(int IdHorario, int id)
        {
            return con.AddHorario(IdHorario, id);
        }


        
        // DELETE api/<LineaController>/5
        [HttpDelete]
        [Route("ParadaAnterior/{id}")]
        public void DeleteParadaAnterior(int id)
        {
            con.DeleteParadaAnterior(id);
        }

       
        // DELETE api/<LineaController>/5
        [HttpDelete()]
        [Route("ParadaLinea/{id}")]
        public void DeleteParada_linea(int id)
        {
            con.DeleteParada_linea(id);
        }

        
        // DELETE api/<LineaController>/5
        [HttpDelete]
        [Route("Horario/{id}")]
        public void DeleteHorario(int IdHorario, int id)
        {
            con.DeleteHorario(IdHorario,id);
        }

        [Route("Paradas/{id}")]
        // GET: api/<LineaController>
        public List<Parada> GetParadas(int id)
        {
            return con.GetParadas(id);
        }

        [Route("AddParada")]
        // Post api/<LineaController>/5
        [HttpPost]
        public void AddParada(DTOaddParada dt)
        {
            con.AddParada(dt);
        }

        //Agregar precio a una ParadaAnterior
        [Route("AddPrecio")]
        // Post api/<LineaController>/5
        [HttpPost]
        public void AddPrecio(DtoPrecio dt)
        {
            con.AddPrecio(dt);
        }



    }
}
