using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.LearnerAssignment
{
    public class UpdateLearnerAssignmentRequest
    {
        public int AccountId { get; set; }
        public int AssignmentId { get; set; }
        public float Mark { get; set; }
        public DateTime AssignmentTakenDate { get; set; }
        public DateTime TakenDuration { get; set; }
    }
}
