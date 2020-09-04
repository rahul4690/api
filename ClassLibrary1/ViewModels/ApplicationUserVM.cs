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
}
