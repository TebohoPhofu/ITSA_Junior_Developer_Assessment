using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Addendum_A.Models
{
    [Table("Class")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(StudentId), IsUnique = true)]
    public partial class Class
    {
        [Key]
        public long Id { get; set; }

        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public long InstructorId { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public DateTime ClassStart { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public DateTime ClassEnd { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Classes")]
        public virtual Course Course { get; set; }

        [ForeignKey(nameof(InstructorId))]
        [InverseProperty("Classes")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Class")]
        public virtual Student Student { get; set; }
    }
}