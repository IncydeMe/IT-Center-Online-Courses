using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.Category
{
    public class UpdateCategoryRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
