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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService manager)
        {
            _orderService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _orderService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(OrderAddDto entity)
        {
            var result = _orderService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(OrderUpdateDto entity)
        {
            var result = _orderService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);
            return Ok(result);
        }
    }
}
