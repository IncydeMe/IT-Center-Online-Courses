using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Response.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IAssignmentService
    {
        public Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId);
        public Task<GetAssignmentResponse> GetAssignmentById(int assignmentId);
        public void CreateAssignment(CreateAssignmentRequest createAssignmentRequest);
        public Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment);
    }

}
