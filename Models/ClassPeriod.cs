using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{
    public class ClassPeriod
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsUpcoming => StartTime > DateTime.Now;
        public bool IsActive => StartTime <= DateTime.Now && EndTime >= DateTime.Now;
    }
}