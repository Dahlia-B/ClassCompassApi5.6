using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClassCompass.Shared.Models
{
    public class BehaviorRemark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Remark { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(100)]
        public string RemarkType { get; set; } = string.Empty; 

        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual Student? Student { get; set; }
    }
}