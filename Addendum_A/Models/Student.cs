using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Addendum_A.Models
{
    [Table("Student")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(StudentNumber), IsUnique = true)]
    public partial class Student
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "INT")]
        public long StudentNumber { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        public string Address { get; set; }

        [InverseProperty("Student")]
        public virtual Class Class { get; set; }
        [InverseProperty("Student")]
        public virtual Mark Mark { get; set; }
    }
}
