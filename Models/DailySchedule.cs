using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models

{
    public class DailySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Date { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public List<ClassPeriod> Periods { get; set; } = new();
        public bool NotificationsEnabled { get; set; } = false;

        [NotMapped]
        public bool HasClasses => Periods.Any();

        [NotMapped]

        public ClassPeriod? NextClass => Periods
            .Where(p => p.IsUpcoming)
            .OrderBy(p => p.StartTime)
            .FirstOrDefault();

        [NotMapped]

        public ClassPeriod? CurrentClass => Periods
            .FirstOrDefault(p => p.IsActive);
    }
}
