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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService manager)
        {
            _addressService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _addressService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _addressService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddressAddDto entity)
        {
            var result = _addressService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(AddressUpdateDto entity)
        {
            var result = _addressService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _addressService.Delete(id);
            return Ok(result);
        }
    }
}
