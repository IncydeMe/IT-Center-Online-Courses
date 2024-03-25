﻿using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.DTOs.Response.LearnerAssignment;
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
    public class LearnerAssignmentService : ILearnerAssignmentService
    {
        private readonly ILearnerAssignmentRepository _learnerAssignmentRepository = null;
        public LearnerAssignmentService()
        {
            if (_learnerAssignmentRepository == null)
                _learnerAssignmentRepository = new LearnerAssignmentRepository();
        }

        public void CreateLearnerAssignment(CreateLearnerAssignmentRequest newLearnerAssignment)
            => _learnerAssignmentRepository.CreateLearnerAssignment(newLearnerAssignment);

        public Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(int learnerAssignmentId, UpdateLearnerAssignmentRequest updateLearnerAssignment)
            => _learnerAssignmentRepository.UpdateLearnerAssignment(learnerAssignmentId, updateLearnerAssignment);
    }
}