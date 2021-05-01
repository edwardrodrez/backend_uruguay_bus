using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using System.Collections.Generic;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers 
{
    
    [RoutePrefix("api/Parada")]
    public class ParadaController : ApiController
    {
        IBL_Parada con = new BL_Parada();

        // GET: api/<ParadaController>
        [HttpGet]
        public List<Parada> Get()
        {
            return con.GetParadas();
        }

        // GET api/<ParadaController>/5
        [HttpGet]
        public Parada Get(int id)
        {
            return con.GetParada(id);
        }

        // POST api/<ParadaController>
        [HttpPost]
        public Parada Post(Parada pa)
        {
          return  con.AddParada(pa);
        }

        // PUT api/<ParadaController>/5
        [HttpPut]
        public Parada Put(Parada pa)
        {
           return con.UpdateParada(pa);
        }

        // DELETE api/<ParadaController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            con.DeleteParada(id);
        }

        // PUT api/<ParadaController>/5
        [HttpPost]
        public void AddParada_linea(Parada_linea pl,int id)
        {
            con.AddParada_linea(pl,id);
        }

    }
}
