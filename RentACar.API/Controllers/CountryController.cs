using Microsoft.AspNetCore.Authorization;
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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService manager)
        {
            _countryService = manager;
        }

        [HttpGet("getall")]
        [Authorize()]
        public IActionResult GetList()
        {
            var result = _countryService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _countryService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CountryAddDto entity)
        {
            var result = _countryService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(CountryUpdateDto entity)
        {
            var result = _countryService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _countryService.Delete(id);
            return Ok(result);
        }
    }
}
