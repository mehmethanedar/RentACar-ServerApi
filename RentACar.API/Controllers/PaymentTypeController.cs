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
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService manager)
        {
            _paymentTypeService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _paymentTypeService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _paymentTypeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PaymentTypeAddDto entity)
        {
            var result = _paymentTypeService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(PaymentTypeUpdateDto entity)
        {
            var result = _paymentTypeService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _paymentTypeService.Delete(id);
            return Ok(result);
        }
    }
}
