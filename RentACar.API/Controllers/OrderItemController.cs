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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService manager)
        {
            _orderItemService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _orderItemService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _orderItemService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(OrderItemAddDto entity)
        {
            var result = _orderItemService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(OrderItemUpdateDto entity)
        {
            var result = _orderItemService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _orderItemService.Delete(id);
            return Ok(result);
        }
    }
}
