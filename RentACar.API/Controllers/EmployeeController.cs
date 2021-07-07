using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService manager)
        {
            _employeeService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _employeeService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee entity)
        {
            var result = _employeeService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(EmployeeUpdateDto entity)
        {
            var result = _employeeService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            return Ok(result);
        }
    }
}
