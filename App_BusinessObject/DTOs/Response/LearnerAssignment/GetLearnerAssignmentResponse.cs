using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.LearnerAssignment
{
    public class GetLearnerAssignmentResponse
    {
        public int LearnerAssignmentId { get; set; }
        public int AccountId { get; set; }
        public int AssignmentId { get; set; }
        public float Mark { get; set; }
        public DateTime AssignmentTakenDate { get; set; }
        public DateTime TakenDuration { get; set; }

        public GetLearnerAssignmentResponse()
        {

        }

        public GetLearnerAssignmentResponse(int learnerAssignmentId, int accountId, int assignmentId, float mark, DateTime assignmentTakenDate, DateTime takenDuration)
        {
            LearnerAssignmentId = learnerAssignmentId;
            AccountId = accountId;
            AssignmentId = assignmentId;
            Mark = mark;
            AssignmentTakenDate = assignmentTakenDate;
            TakenDuration = takenDuration;
        }
    }
}
