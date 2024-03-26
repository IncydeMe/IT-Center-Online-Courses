using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Response.Category;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size);
        public Task CreateCategory(CreateCategoryRequest createCategoryRequest);
        public Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest);
        public Task<GetCategoryResponse> GetRandomCategoy();
    }
}
