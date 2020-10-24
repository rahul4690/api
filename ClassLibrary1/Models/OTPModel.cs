using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Models.Models
{
    public class OTPModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string otp { get; set; }
        public Guid userId { get; set; }
        public DateTime createdOn { get; set; }
        public bool isVerified { get; set; }
    }
}
