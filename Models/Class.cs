using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int ExternalClassCode { get; set; }

        public int TeacherId { get; set; }

        public int SchoolId { get; set; }

        public string Grade { get; set; } = string.Empty;

        public int MaxStudents { get; set; } = 30;

        public bool IsActive { get; set; } = true;

        [NotMapped]
        public List<Student> Students { get; set; } = new();

        [NotMapped]
        public int CurrentEnrollment => Students.Count(s => s.IsActive);
    }
}