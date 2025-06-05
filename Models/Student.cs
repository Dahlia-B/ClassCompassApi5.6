using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public int ClassId { get; set; }
        public ClassRoom ClassRoom { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; }

        public bool IsActive { get; set; } = true;

        public bool NotificationsEnabled { get; set; } = true;

        [NotMapped]
        public List<Grade> Grades { get; set; } = new();

        [NotMapped]
        public List<BehaviorRemark> BehaviorRemarks { get; set; } = new();

        [NotMapped]
        public double OverallAverage => Grades.Any() ? Grades.Average(g => g.Percentage) : 0;

        public ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();

        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; } = new List<HomeworkSubmission>();

    }
}