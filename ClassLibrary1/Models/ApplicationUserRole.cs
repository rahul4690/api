using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models.Models
{
    public class ApplicationUserRole
    {
        [Key]
        public Guid id { get; set; }
        public string roleName { get; set; }
    }
}
