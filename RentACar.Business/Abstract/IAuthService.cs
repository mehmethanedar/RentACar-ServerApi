using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Security.Jwt;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<UserInformation> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<UserInformation> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UserInformation userInformation);
        IResult ActivateAccount(string accountActivationCode);
    }
}
