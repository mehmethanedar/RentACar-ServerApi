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
    public class GearTypeController : ControllerBase
    {
        private readonly IGearTypeService _gearTypeService;

        public GearTypeController(IGearTypeService manager)
        {
            _gearTypeService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _gearTypeService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _gearTypeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(GearTypeAddDto entity)
        {
            var result = _gearTypeService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(GearTypeUpdateDto entity)
        {
            var result = _gearTypeService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _gearTypeService.Delete(id);
            return Ok(result);
        }
    }
}
