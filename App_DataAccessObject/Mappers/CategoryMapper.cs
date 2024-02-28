using AutoMapper;
using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Response.Category;
using App_BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, UpdateCategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
        }
    }
}
