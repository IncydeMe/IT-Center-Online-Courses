using App_BusinessObject.DTOs.Request.Assignment;
using App_BusinessObject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class AssignmentMapper : Profile
    {
        public AssignmentMapper() 
        {
            CreateMap<CreateAssignmentRequest, Assignment>();
            CreateMap<Assignment, UpdateAssignmentRequest>();
        }
    }
}
