using AutoMapper;
using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class OwnedCourseMapper : Profile
    {
        public OwnedCourseMapper()
        {
            CreateMap<CreateOwnedCourseRequest, OwnedCourse>();
        }
    }
}
