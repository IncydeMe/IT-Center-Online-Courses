using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.Models
{
    public class Lesson
    {
        public Lesson()
        {
            OwnedLessons = new HashSet<OwnedLesson>();
        }

        [Key]
        public int LessonId { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Lesson name is required.")]
        [StringLength(100, ErrorMessage = "Lesson name cannot be longer than 100 characters.")]
        public string LessonName { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }
        public string MaterialUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [DefaultValue(false)]
        public bool IsFinished { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<OwnedLesson> OwnedLessons { get; set; }
    }
}
