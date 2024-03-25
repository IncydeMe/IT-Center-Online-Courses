using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.DTOs.Request.LearnerAssignment;
using App_BusinessObject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class LearnerAssignmentMapper : Profile
    {
        public LearnerAssignmentMapper()
        {
            CreateMap<CreateLearnerAssignmentRequest, LearnerAssignment>();
            CreateMap<LearnerAssignment, UpdateLearnerAssignmentRequest>();
        }
    }
}
