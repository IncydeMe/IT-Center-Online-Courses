﻿using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Assignment;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface IAssignmentRepository
    {
        public Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId);
        public Task<GetAssignmentResponse> GetAssignmentById(int assignmentId);
        public void CreateAssignment(CreateAssignmentRequest createAssignmentRequest);
        public Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment);
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        public async Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId) => await AssignmentDAO.Instance.GetAssignmentsInCourse(courseId);
        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId) => await AssignmentDAO.Instance.GetAssignmentById(assignmentId);
        public void CreateAssignment(CreateAssignmentRequest createAssignmentRequest) => AssignmentDAO.Instance.CreateAssignment(createAssignmentRequest);
        public async Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment) => await AssignmentDAO.Instance.UpdateAssignment(assignmentId, updateAssignment);
    }
}