using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassCompass.Shared.Models
{

    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;
        public int SchoolId { get; set; }
        public School School { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [NotMapped]
        public List<string> Subjects
        {
            get => Subject.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            set => Subject = string.Join(",", value.Distinct());
        }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<ClassRoom> ClassRooms { get; set; } = new List<ClassRoom>();
    }
}