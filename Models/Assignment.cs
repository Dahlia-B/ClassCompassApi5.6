using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{
    [Table("Assignments")]
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public double MaxScore { get; set; }
        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string FormattedDueDate => DueDate.ToString("MMM dd, yyyy 'at' h:mm tt");

        [NotMapped]
        public bool IsOverdue => DateTime.Now > DueDate && IsActive;

        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }
    }
}