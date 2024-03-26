using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Category;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task CreateCategory(CreateCategoryRequest createCategoryRequest) => await CategoryDAO.Instance.CreateCategory(createCategoryRequest);

        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size) => await CategoryDAO.Instance.GetAllCategories(page, size);

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest) => await CategoryDAO.Instance.UpdateCategoryInformation(id, updateCategoryRequest);

        public async Task<GetCategoryResponse> GetRandomCategoy() => await CategoryDAO.Instance.GetRandomCategoy();
    }
}
