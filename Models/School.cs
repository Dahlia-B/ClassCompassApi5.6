using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCompass.Shared.Models
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int NumberOfClasses { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<ClassRoom> Classes { get; set; } = new List<ClassRoom>();

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
