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
        public string CategoryName { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }

        public GetCourseResponse()
        {

        }

        public GetCourseResponse(int courseId, string courseName, string description, string categoryName, bool isAvailable, double price, string imageUrl)
        {
            CourseId = courseId;
            CourseName = courseName;
            Description = description;
            CategoryName = categoryName;
            IsAvailable = isAvailable;
            Price = price;
            ImageUrl = imageUrl;
        }
    }
}
