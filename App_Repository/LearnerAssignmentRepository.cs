using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.DTOs.Response.LearnerAssignment;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface ILearnerAssignmentRepository
    {
        public void CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment);
        public Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment);
    }

    public class LearnerAssignmentRepository : ILearnerAssignmentRepository
    {
        public void CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment) => LearnerAssignmentDAO.Instance.CreateLearnerAssignment(newLearnerAssignment);
        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment) => await LearnerAssignmentDAO.Instance.UpdateLearnerAssignment(learnerAssignmentId, updateLearnerAssignment);
    }
}
