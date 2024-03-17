using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Response.Assignment;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public interface IAssignmentService
    {
        public Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId);
        public Task<GetAssignmentResponse> GetAssignmentById(int assignmentId);
        public void CreateAssignment(CreateAssignmentRequest createAssignmentRequest);
        public Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment);
    }

    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository = null;

        public AssignmentService()
        {
            if (_assignmentRepository == null)
                _assignmentRepository = new AssignmentRepository();
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId) => await _assignmentRepository.GetAssignmentById(assignmentId);
        public async Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId) => await _assignmentRepository.GetAssignmentsInCourse(courseId);
        public void CreateAssignment(CreateAssignmentRequest createAssignmentRequest) => _assignmentRepository.CreateAssignment(createAssignmentRequest);
        public async Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment) => await _assignmentRepository.UpdateAssignment(assignmentId, updateAssignment);
    }
}
