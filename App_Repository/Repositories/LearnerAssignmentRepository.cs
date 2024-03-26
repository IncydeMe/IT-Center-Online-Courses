using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.DTOs.Response.LearnerAssignment;
using App_DataAccessObject;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class LearnerAssignmentRepository : ILearnerAssignmentRepository
    {
        public void CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment) => LearnerAssignmentDAO.Instance.CreateLearnerAssignment(newLearnerAssignment);
        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment) => await LearnerAssignmentDAO.Instance.UpdateLearnerAssignment(learnerAssignmentId, updateLearnerAssignment);
    }
}
