using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{
    [Table("ClassRosters")]
    public class ClassRoster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
