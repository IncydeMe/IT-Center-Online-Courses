using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task CreateLesson(CreateLessonRequest createLessonRequest) => await _lessonRepository.CreateLesson(createLessonRequest);

        public async Task<bool> DeleteLesson(int id) => await _lessonRepository.DeleteLesson(id);

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId) => await _lessonRepository.GetAllLessonsOfCourse(courseId);

        public async Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest) => await _lessonRepository.UpdateLessonInformation(id, updateLessonRequest);
    }
}
