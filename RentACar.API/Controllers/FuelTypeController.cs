using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeService _fuelTypeService;

        public FuelTypeController(IFuelTypeService manager)
        {
            _fuelTypeService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _fuelTypeService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _fuelTypeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FuelTypeAddDto entity)
        {
            var result = _fuelTypeService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(FuelTypeUpdateDto entity)
        {
            var result = _fuelTypeService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _fuelTypeService.Delete(id);
            return Ok(result);
        }
    }
}
