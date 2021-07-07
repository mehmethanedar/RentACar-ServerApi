using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _CompanyService;

        public CompanyController(ICompanyService manager)
        {
            _CompanyService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _CompanyService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _CompanyService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Company entity)
        {
            var result = _CompanyService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Company entity)
        {
            var result = _CompanyService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _CompanyService.Delete(id);
            return Ok(result);
        }
    }
}
