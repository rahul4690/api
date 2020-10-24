using Repository.Data.Context;
using Repository.Data.Services.IServices;
using Repository.Models.Models;

namespace Repository.Data.Services
{
    public class OtpRepository : DataAccess<OTPModel>, IOtpRepository
    {
        public OtpRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
