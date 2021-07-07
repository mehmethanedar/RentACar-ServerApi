using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService manager)
        {
            _vehicleService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _vehicleService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(VehicleAddDto entity)
        {
            var result = _vehicleService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(VehicleUpdateDto entity)
        {
            var result = _vehicleService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleService.Delete(id);
            return Ok(result);
        }
    }
}
