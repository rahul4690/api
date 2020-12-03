using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models.Models
{
    [Table("tbl_application_users")]
    public class ApplicationUserModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string aboutMe { get; set; }
        public string image { get; set; }
        public Guid roleId { get; set; }
        public ApplicationUserRoleModel role { get; set; }
        public bool isActive { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

    }
}
