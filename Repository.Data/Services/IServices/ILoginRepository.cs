using Repository.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Services.IServices
{
    public interface ILoginRepository
    {
        string GenerateJSONWebToken(LoginVM userInfo);
        Task<Tuple<bool, LoginVM, string>> AuthenticateUser(LoginVM loginVM);
        Task<ResponseObject> changePassword(ChangePassword request);
        Task<OtpResponseObject> getOtp(string request);
        Task<ResponseObject> forgetPassword(ForgetPassword request);
    }
}
