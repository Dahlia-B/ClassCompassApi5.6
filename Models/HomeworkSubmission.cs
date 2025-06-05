using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{

    public class HomeworkSubmission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmissionId { get; set; }

        [Required]
        public int HomeworkId { get; set; }

        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; } = null!;
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public string? FileURL { get; set; }

        public string? Content { get; set; }

        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Submitted";

        public int? Grade { get; set; }

        public string? TeacherFeedback { get; set; }
    }
}