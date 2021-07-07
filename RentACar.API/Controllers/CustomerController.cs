using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService manager)
        {
            _customerService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _customerService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerAddDto entity)
        {
            var result = _customerService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Customer entity)
        {
            var result = _customerService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);
            return Ok(result);
        }
    }
}
