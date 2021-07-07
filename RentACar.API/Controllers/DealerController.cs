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
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService manager)
        {
            _dealerService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _dealerService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _dealerService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(DealerAddDto entity)
        {
            var result = _dealerService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(DealerUpdateDto entity)
        {
            var result = _dealerService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _dealerService.Delete(id);
            return Ok(result);
        }
    }
}
