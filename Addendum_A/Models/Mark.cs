using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Addendum_A.Models
{
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(StudentId), IsUnique = true)]
    public partial class Mark
    {
        [Key]
        public long Id { get; set; }
        public long? Module1 { get; set; }
        public long? Module2 { get; set; }
        public long? Module3 { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Marks")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Mark")]
        public virtual Student Student { get; set; }
    }
}
