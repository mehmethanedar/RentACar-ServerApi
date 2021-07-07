using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService manager)
        {
            _cityService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _cityService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cityService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CityAddDto entity)
        {
            var result = _cityService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(CityUpdateDto entity)
        {
            var result = _cityService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _cityService.Delete(id);
            return Ok(result);
        }
    }
}
