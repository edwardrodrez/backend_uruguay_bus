using System.Collections.Generic;
using System.Web.Http;
using BusinessLayer.Cast;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Share.Entities;
using Share.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App_Rest.Controllers
{
    [RoutePrefix("api/Viaje")]
 
    public class ViajeController : ApiController
    {
        IBL_Viaje con = new BL_Viaje();
        // GET: api/<ViajeController>
        [HttpGet]
        public List<Viaje> Get()
        {
            return con.GetViajes();
        }

        // GET api/<ViajeController>/5
        [HttpGet]
        public Viaje Get(int id)
        {
            return con.GetViaje(id);
        }

        // POST api/<ViajeController>
        [HttpPost]
        public void Post(DtoViaje vi)
        {
            con.AddViaje(vi);
        }

        // PUT api/<ViajeController>/5
        [HttpPut]
        public void Put(Viaje vi)
        {
            con.UpdateViaje(vi);
        }

        // DELETE api/<ViajeController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            con.DeleteViaje(id);
        }


        // POST api/<ViajeController>
        [HttpPost]
        public void AddPasaje(Pasaje pa, int id)
        {
            con.AddPasaje(pa,id);
        }

        // POST api/<ViajeController>
        [HttpPost]
        public void AddAsiento(Asiento a, int id)
        {
            con.AddAsiento(a, id);
        }

        // POST api/<ViajeController>
        [HttpPost]
        public void AddDia(Dia di, int id)
        {
            con.AddDia(di, id);
        }

        [HttpGet]
        [Route("ViajesChofer/{id}")]
        public List<DtViajeChofer> ViajesChofer(int id)
        {
           return con.ViajesChofer( id);
        }

        [HttpGet]
        [Route("ComensarViaje/{id}")]
        public void ComensarViaje(int id)
        {
            con.comensarViaje(id);
        }

        //Retorna los viajes para esas paradas y dia
        [HttpPost]
        [Route("ViajesPasaje")]
        public List<DtoViajePrecio> ViajePasaje(DtoViajePasaje dto)
        {
            return con.ViajePasaje(dto);
        }

        [HttpPost]
        [Route("ComprarPasaje")]
        public bool ComprarPasaje(DtoComprarPasaje dto)
        {
             return con.ComprarPasaje(dto);
        }

        [HttpPost]
        [Route("ValidarPasaje")]
        public void ValidarPasaje(DtoValidar dto)
        {
            con.ValidarPasaje(dto);
        }

        [HttpGet]
        [Route("ViajesControl")]
        public List<DtoViajeControl> ViajesControl()
        {
           return  con.ViajeControl();
        }

        [HttpGet]
        [Route("MoverVehiculo/{id}")]
        public string MoverVehiculo(int id)
        {
             return con.MoverVehiculo(id);
        }

        [HttpPost]
        [Route("ProximosVehiculos")]
        public List<DtoProximoVehiculoRet> ProximoVehiculo(DtoProximoVehiculo dto)
        {
           return con.ProximoVehiculo(dto);
        }

        [HttpPost]
        [Route("Reportes")]
        public List<ReporteRet> Reportes(Reporte dto)
        {
            return con.Reportes(dto);
        }
    }
}
