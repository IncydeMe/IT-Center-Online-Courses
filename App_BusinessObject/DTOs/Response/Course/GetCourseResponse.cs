using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Course
{
    public class GetCourseResponse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }

        public GetCourseResponse()
        {
            
        }

        public GetCourseResponse(int courseId, string courseName, string description, int categoryId, bool isAvailable, string imageUrl, double price)
        {
            CourseId = courseId;
            CourseName = courseName;
            Description = description;
            CategoryId = categoryId;
            IsAvailable = isAvailable;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}
