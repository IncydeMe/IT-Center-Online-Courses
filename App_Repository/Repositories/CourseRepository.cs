﻿using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
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
    public class CourseRepository : ICourseRepository
    {
        public async Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size) => await CourseDAO.Instance.GetAllCourses(page, size);

        public async Task CreateCourse(CreateCourseRequest createCourseRequest) => await CourseDAO.Instance.CreateCourse(createCourseRequest);

        public async Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest) => await CourseDAO.Instance.UpdateCourseInformation(id, updateCourseRequest);

        public async Task<bool> ChangeCourseStatus(int id) => await CourseDAO.Instance.ChangeCourseStatus(id);

        public async Task<GetCourseResponse> GetCourseById(int courseId) => await CourseDAO.Instance.GetCourseById(courseId);

        public async Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size)
            => await CourseDAO.Instance.GetCoursesByCategoryName(categoryName, page, size);

        public async Task<List<Course>> GetAllCourses() => await CourseDAO.Instance.GetAllCourses();

        public async Task<int> GetTotalCourses() => await CourseDAO.Instance.GetTotalCourses();

        public async Task<Dictionary<string, int>> GetCourseCountsByCategory() => await CourseDAO.Instance.GetCourseCountsByCategory();
    }
}
