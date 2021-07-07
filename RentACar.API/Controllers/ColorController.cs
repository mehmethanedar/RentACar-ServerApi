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
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService manager)
        {
            _colorService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _colorService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ColorAddDto entity)
        {
            var result = _colorService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(ColorUpdateDto entity)
        {
            var result = _colorService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _colorService.Delete(id);
            return Ok(result);
        }
    }
}
