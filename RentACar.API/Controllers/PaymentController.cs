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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService manager)
        {
            _paymentService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _paymentService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _paymentService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(PaymentAddDto entity)
        {
            var result = _paymentService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(PaymentUpdateDto entity)
        {
            var result = _paymentService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _paymentService.Delete(id);
            return Ok(result);
        }
    }
}
