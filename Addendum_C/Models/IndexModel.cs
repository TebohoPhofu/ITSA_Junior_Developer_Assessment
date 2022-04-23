using System;
using System.ComponentModel.DataAnnotations;

namespace Addendum_C.Models
{
    public class IndexModel
    {
        [Required(ErrorMessage = "Please fill in the ID Field!")]
        [MinLength(13,ErrorMessage = "The length of your ID should be 13!")]
        [MaxLength(13,ErrorMessage = "The length of your ID should be 13!")]
        public string IdNumber { get; set; }

        public string BirthDate { get; set; }
        public int Age { get; set; }
        public bool Switch { get; set; }
        public bool Error { get; set; }
        public bool Valid { get; set; }
    }
}