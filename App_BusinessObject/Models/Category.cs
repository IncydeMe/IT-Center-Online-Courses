using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.Models
{
    public class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
