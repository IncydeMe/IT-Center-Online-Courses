using AutoMapper;
using App_BusinessObject.DTOs.Request.OwnedLesson;
using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class OwnedLessonMapper : Profile
    {
        public OwnedLessonMapper()
        {
            CreateMap<CreateOwnedLessonRequest, OwnedLesson>();
        }
    }
}
