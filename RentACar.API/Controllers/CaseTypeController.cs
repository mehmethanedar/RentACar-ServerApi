using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseTypeController : ControllerBase
    {
        private readonly ICaseTypeService _caseTypeService;

        public CaseTypeController(ICaseTypeService manager)
        {
            _caseTypeService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _caseTypeService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _caseTypeService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CaseTypeAddDto entity)
        {
            var result = _caseTypeService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(CaseTypeUpdateDto entity)
        {
            var result = _caseTypeService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _caseTypeService.Delete(id);
            return Ok(result);
        }
    }
}

