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
    public class Assignment
    {
        public Assignment()
        {
            LearnerAssignments = new HashSet<LearnerAssignment>();
        }

        [Key]
        public int AssignmentId { get; set; }
        [DefaultValue(100)]
        [StringLength(100, ErrorMessage = "Assignment title cannot be longer than 100 characters.")]
        public string AssignmentTitle { get; set; }
        [Required(ErrorMessage = "Question is required.")]
        public string Question { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AssignmentDuration { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<LearnerAssignment> LearnerAssignments { get; set; }
    }
}
