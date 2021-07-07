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
    public class VehicleBrandController : ControllerBase
    {
        private readonly IVehicleBrandService _vehicleBrandService;

        public VehicleBrandController(IVehicleBrandService manager)
        {
            _vehicleBrandService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _vehicleBrandService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleBrandService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(VehicleBrandAddDto entity)
        {
            var result = _vehicleBrandService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(VehicleBrandUpdateDto entity)
        {
            var result = _vehicleBrandService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleBrandService.Delete(id);
            return Ok(result);
        }
    }
}
