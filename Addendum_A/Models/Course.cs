using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Addendum_A.Models
{
    [Table("Course")]
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
            Marks = new HashSet<Mark>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [InverseProperty(nameof(Class.Course))]
        public virtual ICollection<Class> Classes { get; set; }
        [InverseProperty(nameof(Mark.Course))]
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
