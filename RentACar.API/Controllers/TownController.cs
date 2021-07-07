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
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;

        public TownController(ITownService manager)
        {
            _townService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _townService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _townService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(TownAddDto entity)
        {
            var result = _townService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(TownUpdateDto entity)
        {
            var result = _townService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _townService.Delete(id);
            return Ok(result);
        }
    }
}
