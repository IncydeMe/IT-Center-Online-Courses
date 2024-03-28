using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface ICourseService
    {
        public Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size);
        public Task CreateCourse(CreateCourseRequest createCourseRequest);
        public Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest);
        public Task<bool> ChangeCourseStatus(int id);
        public Task<GetCourseResponse> GetCourseById(int courseId);
        public Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size);
        public Task<List<Course>> GetAllCourses();
        public Task<int> GetTotalCourses();
    }
}
