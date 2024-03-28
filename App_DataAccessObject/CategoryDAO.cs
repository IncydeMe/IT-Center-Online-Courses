using AutoMapper;
using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Response.Category;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App_DataAccessObject
{
    public class CategoryDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public CategoryDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new CategoryMapper())).CreateMapper().ConfigurationProvider);
        }

        #region CategoryFunction
        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size)
        {
            IPaginate<GetCategoryResponse> categoryList = await _dbContext.Categories.Select(x => new GetCategoryResponse
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToPaginateAsync(page, size, 1);
            return categoryList;
        }

        public async Task CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            //Can use Equals, Compare for better performance 
            //Or ToUpperCase for more percisely in some cases, because there are ome upper case characters doesn't have an
            //equivalent lower case character,so making them lower case would convert them into a different lower case character 
            Category? category = _dbContext.Categories.FirstOrDefault(x => x.CategoryName.ToLower() == createCategoryRequest.CategoryName.ToLower());

            if (category == null)
            {
                _dbContext.Categories.Add(_mapper.Map<Category>(createCategoryRequest));
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            Category? category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return null;
            }
                category.CategoryName = string.IsNullOrEmpty(updateCategoryRequest.CategoryName) ?
                    category.CategoryName : updateCategoryRequest.CategoryName;
                category.Description = string.IsNullOrEmpty(updateCategoryRequest.Description) ?
                    category.Description : updateCategoryRequest.Description;

                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();

                UpdateCategoryResponse response = _mapper.Map<UpdateCategoryResponse>(category);
                return response;
        }

        public async Task<GetCategoryResponse> GetRandomCategoy()
        {
            Random rd = new Random();
            int categoriesAmount = await _dbContext.Categories.CountAsync();
            int toSkip = rd.Next(0, categoriesAmount - 1);

            GetCategoryResponse randomCategory = await _dbContext.Categories
                                                 .Select(ct => new GetCategoryResponse
                                                 {
                                                     CategoryId = ct.CategoryId,
                                                     CategoryName = ct.CategoryName,
                                                     Description = ct.Description,
                                                 })
                                                 .Skip(toSkip).Take(1).FirstAsync();
            return randomCategory;
        }
        #endregion
    }
}
