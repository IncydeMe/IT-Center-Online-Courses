using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.DTOs.Response.LearnerAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Interfaces
{
    public interface ILearnerAssignmentRepository
    {
        public Task CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment);
        public Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment);
    }
}
