using App_BusinessObject.DTOs.Response.Course;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_BusinessObject.Models
{
    public class Course
    {
        public Course()
        {
            Lessons = new HashSet<Lesson>();
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
            Assignments = new HashSet<Assignment>();
            OwnedCourses = new HashSet<OwnedCourse>();
        }

        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Course name is required.")]
        [StringLength(100, ErrorMessage = "Course name cannot be longer than 100 characters.")]
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public double Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<OwnedCourse> OwnedCourses { get; set; }

        public static implicit operator Course(GetCourseResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
