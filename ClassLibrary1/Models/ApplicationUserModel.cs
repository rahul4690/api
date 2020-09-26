using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models.Models
{
    public class ApplicationUserModel
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public Guid roleId { get; set; }
        
        [ForeignKey("roleId")]
        public ApplicationUserRoleModel role { get; set; }
        public bool isActive { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

    }
}
