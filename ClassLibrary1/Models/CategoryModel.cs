using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models.Models
{
    [Table("tbl_category")]
    public class CategoryModel
    {
        public string categoryCode { get; set; }
        public string categoryName { get; set; }
        public string categoryImage { get; set; }
        public DateTime createdDate { get; set; }
        public bool isActive { get; set; }
    }
}
