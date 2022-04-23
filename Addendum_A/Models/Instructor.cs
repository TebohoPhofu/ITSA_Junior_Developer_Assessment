using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Addendum_A.Models
{
    [Table("Instructor")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class Instructor
    {
        public Instructor()
        {
            Classes = new HashSet<Class>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [InverseProperty(nameof(Class.Instructor))]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
