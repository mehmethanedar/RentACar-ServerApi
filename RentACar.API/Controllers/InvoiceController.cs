using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Update;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService manager)
        {
            _invoiceService = manager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _invoiceService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _invoiceService.GetById(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(InvoiceAddDto entity)
        {
            var result = _invoiceService.Add(entity);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(InvoiceUpdateDto entity)
        {
            var result = _invoiceService.Update(entity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _invoiceService.Delete(id);
            return Ok(result);
        }
    }
}
