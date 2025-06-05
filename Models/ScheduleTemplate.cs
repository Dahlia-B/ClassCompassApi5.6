using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{
    [Table("ScheduleTemplates")]
    public class ScheduleTemplate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public int PeriodsPerWeek { get; set; }
        public int Duration { get; set; } 
        public string PreferredDays { get; set; } = string.Empty; 
        public bool IsCore { get; set; } = true; 
    }
}
