using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public interface ICourseService
    {
        public Task<IPaginate<GetCourseResponse>> GetAllACourses(int page, int size);
        public void CreateCourse(CreateCourseRequest createCourseRequest);
        public Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest);
        public Task<bool> ChangeCourseStatus(int id);
        public Task<Course> GetCourseById(int courseId);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository = null;
        public CourseService()
        {
            if (_courseRepository == null)
                _courseRepository = new CourseRepository();
        }
        public async Task<bool> ChangeCourseStatus(int id) => await _courseRepository.ChangeCourseStatus(id);

        public async void CreateCourse(CreateCourseRequest createCourseRequest) => _courseRepository.CreateCourse(createCourseRequest);

        public async Task<IPaginate<GetCourseResponse>> GetAllACourses(int page, int size) => await _courseRepository.GetAllCourses(page, size);

        public async Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest) => await _courseRepository.UpdateCourseInformation(id, updateCourseRequest);

        public async Task<Course> GetCourseById(int courseId) => await _courseRepository.GetCourseById(courseId);
    }
}
