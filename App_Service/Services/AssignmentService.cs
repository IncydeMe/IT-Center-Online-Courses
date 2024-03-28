using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Response.Assignment;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId) => await _assignmentRepository.GetAssignmentById(assignmentId);
        public async Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId) => await _assignmentRepository.GetAssignmentsInCourse(courseId);
        public async Task CreateAssignment(CreateAssignmentRequest createAssignmentRequest) => await _assignmentRepository.CreateAssignment(createAssignmentRequest);
        public async Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment) => await _assignmentRepository.UpdateAssignment(assignmentId, updateAssignment);
    }
}
