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
        public Task<IPaginate<GetCourseResponse>> GetAllACourses(int page, int size);
        public Task CreateCourse(CreateCourseRequest createCourseRequest);
        public Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest);
        public Task<bool> ChangeCourseStatus(int id);
        public Task<Course> GetCourseById(int courseId);
    }
}
