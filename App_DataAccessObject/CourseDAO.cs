using AutoMapper;
using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App_DataAccessObject
{
    public class CourseDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static CourseDAO instance;
        public static CourseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseDAO();
                }
                return instance;
            }
        }

        public CourseDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new CourseMapper())).CreateMapper().ConfigurationProvider);
        }

        public async Task CreateCourse(CreateCourseRequest newCourse)
        {
            //Check is name duplicated

            _dbContext.Courses.Add(_mapper.Map<Course>(newCourse));
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size)
        {
            IPaginate<GetCourseResponse> courseList = await _dbContext.Courses
                .Include(c => c.Category)
                .Select(x => new GetCourseResponse
                {
                    CourseId = x.CourseId,
                    CourseName = x.CourseName,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsAvailable = x.IsAvailable,
                    CategoryName = x.Category.CategoryName,
                    Price = x.Price
                }).Where(x => x.IsAvailable == true).ToPaginateAsync(page, size, 1);
            return courseList;
        }

        public async Task<bool> ChangeCourseStatus(int courseId)
        {
            Course? course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId.Equals(courseId));

            if (course != null)
            {
                course.IsAvailable = !course.IsAvailable;
                _dbContext.Courses.Update(course);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UpdateCourseResponse?> UpdateCourseInformation(int courseId, UpdateCourseRequest updateCourseRequest)
        {
            Course? course = await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId.Equals(courseId));
            if (course == null)
            {
                return null;
            }
                course.CourseName = updateCourseRequest.CourseName;
                course.Description = updateCourseRequest.Description;
                course.CategoryId = updateCourseRequest.CategoryId;
                course.Price = updateCourseRequest.Price;
                course.ImageUrl = updateCourseRequest.ImageUrl;
                _dbContext.Courses.Update(course);
                await _dbContext.SaveChangesAsync();

                UpdateCourseResponse response = _mapper.Map<UpdateCourseResponse>(course);
                return response;
        }

        public async Task<GetCourseResponse?> GetCourseById(int courseId)
        {
            GetCourseResponse? response = await _dbContext.Courses
                .Include(c => c.Category)
                .Select(x => new GetCourseResponse
                {
                    CourseId = x.CourseId,
                    CourseName = x.CourseName,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    IsAvailable = x.IsAvailable,
                    CategoryName = x.Category.CategoryName,
                    Price = x.Price
                }).FirstOrDefaultAsync(x => x.CourseId.Equals(courseId));
            return response;
        }

        public async Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size)
        {
            //Check Category Name is exist
            Category? category = _dbContext.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
            if (category == null) throw new BadHttpRequestException("Category name is not existed");

            return await _dbContext.Courses.Include(c => c.Category)
                                           .Where(c => c.Category.CategoryName.Equals(categoryName))
                                           .ToPaginateAsync(page, size, 1);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            List<Course> courseList = await _dbContext.Courses.ToListAsync();
            return courseList;
        }

        public async Task<int> GetTotalCourses()
        {
            return await _dbContext.Courses.CountAsync();
        }

        public async Task<Dictionary<string, int>> GetCourseCountsByCategory()
        {
            return await _dbContext.Courses
                .GroupBy(c => c.Category.CategoryName)
                .Select(g => new { CategoryName = g.Key, CourseCount = g.Count() })
                .ToDictionaryAsync(x => x.CategoryName, x => x.CourseCount);
        }


    }
}
