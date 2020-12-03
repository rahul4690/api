using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.ViewModels
{
    public class CategoryVM
    {
        public string categoryCode { get; set; }
        public string categoryName { get; set; }
        public string categoryImage { get; set; }
        public DateTime createdDate { get; set; }
        public bool isActive { get; set; }
    }
}
