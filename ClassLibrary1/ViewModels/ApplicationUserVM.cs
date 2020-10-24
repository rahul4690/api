using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.ViewModels
{
    public class ApplicationUserVM
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public Guid roleId { get; set; }
        public bool isActive { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
    }

    public class ChangePassword
    {
        public Guid id { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }

    }

    public class Otp
    {
        public string otp { get; set; }
    }

    public class OtpResponseObject
    {
        public OtpResponseObject()
        {
            otp = new Otp();
        }
        public bool status { get; set; }
        public string message { get; set; }
        public Otp otp { get; set; }

    }

    public class ForgetPassword
    {
        public Guid userId { get; set; }
        public string newPassword { get; set; }
        public string otp { get; set; }
    }

}
