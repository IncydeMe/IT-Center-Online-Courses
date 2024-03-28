using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.LearnerAssignment;
using App_BusinessObject.DTOs.Response.Lesson;
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
    public class LearnerAssignmentDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static LearnerAssignmentDAO instance;
        public static LearnerAssignmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LearnerAssignmentDAO();
                }
                return instance;
            }
        }

        public LearnerAssignmentDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new LearnerAssignmentMapper())).CreateMapper().ConfigurationProvider);
        }

        public async Task CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment)
        {
            _dbContext.LearnerAssignments.Add(_mapper.Map<LearnerAssignment>(newLearnerAssignment));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment)
        {
            LearnerAssignment? learnerAssignment = await _dbContext.LearnerAssignments
                .FirstOrDefaultAsync(x => x.LearnerAssignmentId == learnerAssignmentId) 
                ?? throw new KeyNotFoundException("Learner Assignment not found");
            learnerAssignment.AccountId = updateLearnerAssignment.AccountId;
                learnerAssignment.AssignmentId = updateLearnerAssignment.AssignmentId;
                learnerAssignment.Mark = learnerAssignment.Mark;
                learnerAssignment.AssignmentTakenDate = learnerAssignment.AssignmentTakenDate;
                learnerAssignment.TakenDuration = learnerAssignment.TakenDuration;
                _dbContext.LearnerAssignments.Update(learnerAssignment);
                await _dbContext.SaveChangesAsync();

                UpdateLearnerAssignmentResponse response = _mapper.Map<UpdateLearnerAssignmentResponse>(learnerAssignment);
                return response;
        }
    }
}
