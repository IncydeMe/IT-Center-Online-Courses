using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.LearnerAssignment
{
    public class CreateLearnerAssignmentRequest
    {
        public int AccountId { get; set; }
        public int AssignmentId { get; set; }
        public float Mark { get; set; }
        public DateTime AssignmentTakenDate { get; set; }
        public DateTime TakenDuration { get; set; }
    }
}
