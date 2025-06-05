using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClassId { get; set; }

        public string Class { get; set; } = string.Empty;

        [Required]
        public string RoomNumber { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Schedule { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public int Capacity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int SchoolId { get; set; }
        public School School { get; set; } = null!;

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();

        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; } = new List<HomeworkSubmission>();

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}