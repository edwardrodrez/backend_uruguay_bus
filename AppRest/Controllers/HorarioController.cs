using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using DataAccesLayer.Implementations;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers
{
    [RoutePrefix("api/Horario")]
    public class HorarioController : ApiController
    {
        IBL_Horario con = new BL_Horario();

        // GET: api/<HorarioController>
        [HttpGet]
        public List<Horario> Get()
        {
            return con.GetHorario();
        }

        // GET api/<HorarioController>/5
        [HttpGet] 
        public Horario Get(int id)
        {
            return con.GetHorario(id);
        }
        /*
        // POST api/<HorarioController>
        [HttpPost]
        public void Post(Horario Horario)
        {
            con.AddHorario(Horario);
        }
        */

        // POST api/<HorarioController>
        [HttpPost]
        public void Post(DtoHorario dt)
        {
            con.AddHorario(dt);
        }


        // PUT api/<HorarioController>/5
        [HttpPut]
        public void Put(Horario Horario)
        {
            con.UpdateHorario(Horario);
        }

        // DELETE api/<HorarioController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            con.DeleteHorario(id);
        }


        // PUT api/<HorarioController>/5
        [HttpPut]
        [Route("Vehiculo")]
        public Vehiculo AddVehiculo(int IdVehiculo, int id)
        {
          return  con.AddVehiculo(IdVehiculo,id);
        }


        // PUT api/<HorarioController>/5
        [HttpPut]
        [Route("Usuario")]
        public Usuario AddUsuario(int IdUsuario, int id)
        {
            return con.AddUsuario(IdUsuario, id);
        }


        // PUT api/<HorarioController>/5
        [HttpPut]
        [Route("Linea")]
        public Linea addLinea(int IdLinea, int id)
        {
            return con.AddLinea(IdLinea, id);
        }

        [HttpDelete]
        [Route("Vehiculo/{id}")]
        public void DeleteVehiculo(int IdVehiculo, int id)
        {
            con.DeleteVehiculo(IdVehiculo,id);
        }

      
        [HttpDelete]
        [Route("Usuario/{id}")]
        public void DeleteUsuario(int IdUsuario, int id)
        {
            con.DeleteUsuario(IdUsuario, id);
        }

        
        [HttpDelete]
        [Route("Linea/{id}")]
        public void DeleteLinea(int IdLinea, int id)
        {
            con.DeleteLinea(IdLinea, id);
        }
        


    }
}
