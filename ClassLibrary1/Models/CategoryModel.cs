using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models.Models
{
    public class CategoryModel
    {
        [Key]
        public string categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
