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
    public class VehicleCategoryController : ControllerBase
    {
        private readonly IVehicleCategoryService _vehicleCategoryService;

        public VehicleCategoryController(IVehicleCategoryService manager)
        {
            _vehicleCategoryService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _vehicleCategoryService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleCategoryService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(VehicleCategoryAddDto entity)
        {
            var result = _vehicleCategoryService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(VehicleCategoryUpdateDto entity)
        {
            var result = _vehicleCategoryService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleCategoryService.Delete(id);
            return Ok(result);
        }
    }
}
