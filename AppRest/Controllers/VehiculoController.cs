using BusinessLayer.Implementations;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System.Collections.Generic;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers
{
    [RoutePrefix("api/Vehiculo")]
    [Authorize]
    public class VehiculoController : ApiController
    {
        IBL_vehiculo IBL = new BL_vehiculo();
        // GET: api/Vehiculo
        [HttpGet]
        public List<Vehiculo> Get()
        {
            return IBL.GetVehiculos();
        }

        // GET api/Vehiculo/5
        [HttpGet]
        public Vehiculo Get(int id)
        {
            return IBL.GetVehiculo(id);
        }

        // POST api/Vehiculo

        [HttpPost]
        public Vehiculo add(Vehiculo v)
        {
            return IBL.AddVehiculo(v);
        }

        // PUT api/Vehiculo/5
        [HttpPut]
        public void Put(Vehiculo v)
        {
            IBL.UpdateVehiculo(v);
        }

        // DELETE api/Vehiculo/5
        [HttpDelete]
        public void Delete(int id)
        {
            IBL.DeleteVehiculo(id);
        }
    }
}
