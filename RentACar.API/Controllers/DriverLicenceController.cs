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
    public class DriverLicenceController : ControllerBase
    {
        private readonly IDriverLicenceService _driverLicenceService;

        public DriverLicenceController(IDriverLicenceService manager)
        {
            _driverLicenceService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _driverLicenceService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _driverLicenceService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(DriverLicenceAddDto entity)
        {
            var result = _driverLicenceService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(DriverLicenceUpdateDto entity)
        {
            var result = _driverLicenceService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _driverLicenceService.Delete(id);
            return Ok(result);
        }
    }
}
