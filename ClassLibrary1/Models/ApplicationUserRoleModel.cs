using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models.Models
{
    [Table("tbl_application_users_role")]
    public class ApplicationUserRoleModel
    {
        [Key]
        public Guid id { get; set; }
        public string roleName { get; set; }
        public ICollection<ApplicationUserModel> applicationUsers { get; set; }
    }
}
