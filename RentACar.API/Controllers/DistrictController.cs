using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService manager)
        {
            _districtService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _districtService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _districtService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(DistrictAddDto entity)
        {
            var result = _districtService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(DistrictUpdateDto entity)
        {
            var result = _districtService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _districtService.Delete(id);
            return Ok(result);
        }
    }
}
