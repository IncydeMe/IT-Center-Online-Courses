using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Response.Category;
using App_BusinessObject.Paginate;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(CreateCategoryRequest createCategoryRequest) => await _categoryRepository.CreateCategory(createCategoryRequest);

        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size) => await _categoryRepository.GetAllCategories(page, size);

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest) => await _categoryRepository.UpdateCategoryInformation(id, updateCategoryRequest);
    }
}
