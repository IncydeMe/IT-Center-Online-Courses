using AutoMapper;
using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class LessonMapper : Profile
    {
        public LessonMapper()
        {
            CreateMap<CreateLessonRequest, Lesson>();
            CreateMap<Lesson, UpdateLessonResponse>();
        }
    }
}
