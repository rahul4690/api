using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Data.Services.IServices;
using Repository.Models.Models;
using Repository.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Services
{
    public class LoginRepository : ILoginRepository
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IConfiguration _configuration;
        public LoginRepository(IRepositoryWrapper repositoryWrapper, IConfiguration configuration)
        {
            _repositoryWrapper = repositoryWrapper;
            _configuration = configuration;
        }

        public string GenerateJSONWebToken(LoginVM userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var getKey = _configuration["Jwt:Key"];
            var key = Encoding.ASCII.GetBytes(getKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, userInfo.userName),
                    new Claim(ClaimTypes.Role, userInfo.role)
               }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var createToken = tokenHandler.CreateToken(tokenDescriptor);
            string _token = tokenHandler.WriteToken(createToken);
            return _token;
        }

        public async Task<Tuple<bool, LoginVM, string>> AuthenticateUser(LoginVM loginVM)
        {
            LoginVM response = new LoginVM();
            bool status = false;
            string message = string.Empty;
            var findUser = await _repositoryWrapper.userRepository.GetAll(x => x.email.ToLower() == loginVM.userName.ToLower());
            if (findUser.Count() > 0)
            {
                var verifyPassword = (findUser.FirstOrDefault().password == loginVM.password);
                if (verifyPassword)
                {
                    status = true;
                    response.userName = findUser.FirstOrDefault().email;
                    response.password = findUser.FirstOrDefault().password;
                    var findRoleId = await _repositoryWrapper.roleRepository.GetById(findUser.FirstOrDefault().roleId);
                    response.role = findRoleId.roleName;
                }
                else
                {
                    status = false;
                    message = "Incorrect Password";
                }
            }
            else
            {
                status = false;
                message = "User not found";
            }
            return Tuple.Create(status, response, message);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseObject> changePassword(ChangePassword request)
        {
            ResponseObject response = new ResponseObject();
            if (request != null && request.newPassword == request.confirmPassword)
            {
                var findUser = await _repositoryWrapper.userRepository.GetById(request.id);
                if (findUser != null)
                {
                    if (findUser.password == request.oldPassword)
                    {
                        findUser.password = request.newPassword;
                        _repositoryWrapper.userRepository.Update(findUser);
                        _repositoryWrapper.Save();
                        response.status = true;
                        response.message = "Password changed successfully";
                    }
                    else
                    {
                        response.status = false;
                        response.message = "Enter old password correctly";
                    }
                }
                else
                {
                    response.status = false;
                    response.message = "User not found";
                }
            }
            return response;
        }


        /// <summary>
        /// Get OTP when user is authenticated
        /// </summary>
        /// <returns></returns>
        public async Task<OtpResponseObject> getOtp(string request)
        {
            OtpResponseObject response = new OtpResponseObject();
            try
            {

                var findUser = await _repositoryWrapper.userRepository.GetById(Guid.Parse(request));
                if (findUser != null)
                {
                    Random r = new Random();
                    int genRand = r.Next(1, 999999);
                    response.otp.otp = genRand.ToString("000000");
                    //Save OTP to DB
                    OTPModel otpModel = new OTPModel();
                    otpModel.createdOn = DateTime.Now;
                    otpModel.userId = findUser.id;
                    otpModel.otp = response.otp.otp;
                    await _repositoryWrapper.otpRepository.Add(otpModel);
                    _repositoryWrapper.Save();
                    response.status = true;
                    response.message = "OTP generated successfully";
                }
                else
                {
                    response.status = false;
                    response.message = "User not found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<ResponseObject> forgetPassword(ForgetPassword request)
        {
            ResponseObject response = new ResponseObject();
            var findUser = await _repositoryWrapper.userRepository.GetById(request.userId);
            if (findUser != null)
            {
                var getotp = await _repositoryWrapper.otpRepository.GetAll(x => x.userId == request.userId);
                if (getotp.LastOrDefault().otp == request.otp)
                {
                    //Updating the OTP status when verified so it cant be used again
                    getotp.LastOrDefault().isVerified = true;
                    _repositoryWrapper.Save();

                    //Updating the Password
                    findUser.password = request.newPassword;
                    _repositoryWrapper.userRepository.Update(findUser);
                    _repositoryWrapper.Save();
                    response.status = true;
                    response.message = "Password updated successfully";
                }
                else
                {
                    response.status = true;
                    response.message = "Enter correct OTP";
                }
            }
            return response;
        }



    }
}
