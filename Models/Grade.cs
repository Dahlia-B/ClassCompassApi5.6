using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{
    [Table("Grades")]
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign Keys
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int ClassRoomId { get; set; }
        public int AssignmentId { get; set; }

        // Navigation Properties
        public Student Student { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
        public Class Class { get; set; } = null!;
        public ClassRoom ClassRoom { get; set; } = null!;
        public Assignment Assignment { get; set; } = null!;

        // Other Fields
        public string Subject { get; set; } = string.Empty;
        public string AssignmentType { get; set; } = string.Empty;
        public double? Score { get; set; }
        public double MaxScore { get; set; }
        public DateTime DateRecorded { get; set; }
        public string Comments { get; set; } = string.Empty;
        public bool IsExcused { get; set; } = false;

        // Computed
        [NotMapped]
        public double Percentage => MaxScore > 0 && Score.HasValue ? Math.Round((Score.Value / MaxScore) * 100, 2) : 0;

        [NotMapped]
        public string DisplayGrade => IsExcused ? "Excused" : $"{Score?.ToString() ?? "N/A"}/{MaxScore} ({Percentage}%)";

        [NotMapped]
        public string FormattedDate => DateRecorded.ToString("MMM dd, yyyy");
    }
}