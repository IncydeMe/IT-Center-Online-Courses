using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
using App_BusinessObject.Models;
using App_DataAccessObject.Mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject
{
    public class LessonDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static LessonDAO instance;
        public static LessonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LessonDAO();
                }
                return instance;
            }
        }

        public LessonDAO()
        {
            if(_dbContext == null)
                _dbContext = new ITCenterContext();
            if(_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new LessonMapper())).CreateMapper().ConfigurationProvider);
        }

        public async void CreateLesson(CreateLessonRequest newLesson)
        {
            _dbContext.Lessons.Add(_mapper.Map<Lesson>(newLesson));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId)
        {
            List<GetLessonResponse> lessonList =  _dbContext.Lessons.Select(x => new GetLessonResponse
            {
                LessonId = x.LessonId,
                LessonName = x.LessonName,
                CourseId = x.CourseId,
                Type = x.Type,
                MaterialUrl = x.MaterialUrl,
                IsFinished = x.IsFinished
            }).Where(c => c.CourseId == courseId).ToList();
            return lessonList;
        }

        public List<GetLessonResponse> GetListLessonOfCourse(int courseId)
        {
            List<GetLessonResponse> lessonList = _dbContext.Lessons.Select(x => new GetLessonResponse
            {
                LessonId = x.LessonId,
                LessonName = x.LessonName,
                CourseId = x.CourseId,
                Type = x.Type,
                MaterialUrl = x.MaterialUrl,
                IsFinished = x.IsFinished
            }).Where(c => c.CourseId == courseId).ToList();
            return lessonList;
        }

        public async Task<UpdateLessonResponse> UpdateLesson(int lessonId, UpdateLessonRequest updateLesson)
        {
            Lesson lesson = await _dbContext.Lessons.FirstOrDefaultAsync(x => x.LessonId == lessonId);
            if (lesson != null)
            {
                lesson.LessonName = updateLesson.LessonName;
                lesson.Type = updateLesson.Type;
                lesson.MaterialUrl = updateLesson.MaterialUrl;
                lesson.UpdatedAt = DateTime.Now;
                _dbContext.Lessons.Update(lesson);
                await _dbContext.SaveChangesAsync();

                UpdateLessonResponse response = _mapper.Map<UpdateLessonResponse>(lesson);
                return response;
            }
            return null;
        }

        public async Task<bool> DeleteLesson(int lessonId)
        {
            Lesson lesson = _dbContext.Lessons.FirstOrDefault(x => x.LessonId.Equals(lessonId));

            if (lesson != null)
            {
                _dbContext.Lessons.Remove(lesson);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
