using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Category
{
    public class GetCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public GetCategoryResponse()
        {
            
        }

        public GetCategoryResponse(int id, string categoryName, string description)
        {
            CategoryId = id;
            CategoryName = categoryName;
            Description = description;
        }
    }
}
