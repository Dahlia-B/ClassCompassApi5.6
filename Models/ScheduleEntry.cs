using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{
    [Table("ScheduleEntries")]
    public class ScheduleEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int WeekNumber { get; set; } 
        public string Room { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string FormattedTime => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}";

        [NotMapped]
        public string DisplayText => $"{Subject} - {FormattedTime}";
    }
}
