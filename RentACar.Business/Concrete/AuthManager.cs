using RentACar.Business.Abstract;
using RentACar.Business.Contants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.Core.Utilities.Security.Hashing;
using RentACar.Core.Utilities.Security.Jwt;
using RentACar.Core.Utilities.SMTP;
using RentACar.Entities.Dtos;
using System;

namespace RentACar.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserInformationService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserInformationService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<UserInformation> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new UserInformation
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false
            };
            user.ActivationCode = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            string frontEndUrl = "http://127.0.0.1:5500/view/activateaccount.html";
            string subject = "Verify Your Account";
            string body = $"<html><body><strong>Account verify link:</strong><br><span>{frontEndUrl}?resetcode={user.ActivationCode}</span></body></html>";
            //MailHelper.SendMail(userForRegisterDto.Email, subject, body);
            _userService.Add(user);
            return new SuccessDataResult<UserInformation>(user, Messages.UserRegistered);
        }

        public IDataResult<UserInformation> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserInformation>(Messages.UserNotFound);
            }
            if (userToCheck.Status == false)
            {
                return new ErrorDataResult<UserInformation>(Messages.AccountActivationNecessary);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserInformation>(Messages.PasswordError);
            }

            return new SuccessDataResult<UserInformation>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult("Başarılıı");
        }

        public IDataResult<AccessToken> CreateAccessToken(UserInformation userInformation)
        {
            var claims = _userService.GetClaims(userInformation);
            var accessToken = _tokenHelper.CreateToken(userInformation, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult ActivateAccount(string accountActivationCode)
        {
            try
            {
                var resp = _userService.ActivateAccount(accountActivationCode);
                if (resp.Status)
                    return new SuccessResult("Başarılı");

                return new ErrorResult(Messages.AccountActivationCodeInvalid);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccurred);
            }
        }
    }
}
