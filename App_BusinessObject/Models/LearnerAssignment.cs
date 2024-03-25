using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.Models
{
    public class LearnerAssignment
    {
        [Key]
        public int LearnerAssignmentId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        [ForeignKey("AssignmentId")]
        public int AssignmentId { get; set; }
        [Range(0, 100, ErrorMessage = "Mark must be between 0 and 100.")]
        public float Mark { get; set; }
        [Required(ErrorMessage = "Assignment taken date is required.")]
        public DateTime AssignmentTakenDate { get; set; }
        [Required(ErrorMessage = "Taken duration is required.")]
        public DateTime TakenDuration { get; set; }

        public virtual Account Account { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
