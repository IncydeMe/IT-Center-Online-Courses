using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<bool> ChangeCourseStatus(int id) => await _courseRepository.ChangeCourseStatus(id);

        public async Task CreateCourse(CreateCourseRequest createCourseRequest) => await _courseRepository.CreateCourse(createCourseRequest);

        public async Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size) => await _courseRepository.GetAllCourses(page, size);

        public async Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest) => await _courseRepository.UpdateCourseInformation(id, updateCourseRequest);

        public async Task<GetCourseResponse> GetCourseById(int courseId) => await _courseRepository.GetCourseById(courseId);

        public async Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size)
            => await _courseRepository.GetCoursesByCategoryName(categoryName, page, size);

        public async Task<List<Course>> GetAllCourses() => await _courseRepository.GetAllCourses();

        public async Task<int> GetTotalCourses() => await _courseRepository.GetTotalCourses();
    }
}
