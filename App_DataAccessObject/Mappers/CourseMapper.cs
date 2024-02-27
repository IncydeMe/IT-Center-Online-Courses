using AutoMapper;
using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, UpdateCourseResponse>();
        }
    }
}
