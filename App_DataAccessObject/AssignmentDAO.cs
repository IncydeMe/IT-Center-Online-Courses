using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Assignment;
using App_BusinessObject.DTOs.Response.Lesson;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Models;
using App_DataAccessObject.Mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject
{
    public class AssignmentDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static AssignmentDAO instance;
        public static AssignmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssignmentDAO();
                }
                return instance;
            }
        }

        private AssignmentDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new AssignmentMapper())).CreateMapper().ConfigurationProvider);
        }

        #region AssignmentFunction
        public async Task<List<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId)
        {
            List<Assignment> assignments = await _dbContext.Assignments
                .Where(x => x.CourseId == courseId)
                .ToListAsync();

            List<GetAssignmentResponse> responses = _mapper.Map<List<GetAssignmentResponse>>(assignments);
            return responses;
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId)
        {
            Assignment assignment = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.AssignmentId == assignmentId);
            if (assignment != null)
            {
                GetAssignmentResponse response = _mapper.Map<GetAssignmentResponse>(assignment);
                return response;
            }
            return null;
        }

        public async void CreateAssignment(CreateAssignmentRequest createAssignmentRequest)
        {
            _dbContext.Assignments.Add(_mapper.Map<Assignment>(createAssignmentRequest));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UpdateAssignmentResponse> UpdateAssignment(int assignmentId, UpdateAssignmentRequest updateAssignment)
        {
            Assignment assignment = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.AssignmentId == assignmentId);
            if (assignment != null)
            {
                assignment.AssignmentTitle = updateAssignment.AssignmentTitle;
                assignment.Question = updateAssignment.Question;
                assignment.Deadline = DateTime.Now;
                assignment.Type = updateAssignment.Type;
                assignment.CourseId = updateAssignment.CourseId;
                assignment.AssignmentDuration = DateTime.Now;
                _dbContext.Assignments.Update(assignment);
                await _dbContext.SaveChangesAsync();

                UpdateAssignmentResponse response = _mapper.Map<UpdateAssignmentResponse>(assignment);
                return response;
            }
            return null;
        }
        #endregion
    }
}
