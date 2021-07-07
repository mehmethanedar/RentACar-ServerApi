using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService _userInformationService;

        public UserInformationController(IUserInformationService manager)
        {
            _userInformationService = manager;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _userInformationService.GetList();
            return Ok(result);
        }
        //[HttpGet("getall")]
        //public IActionResult GetClaims()
        //{
        //    var result = _userInformationService.GetClaims(UserInformation userInformation);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
