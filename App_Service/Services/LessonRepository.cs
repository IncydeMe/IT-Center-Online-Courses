using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Services
{
    public interface ILessonRepository
    {
        public Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId);
        public List<GetLessonResponse> GetListLessonOfCourse(int courseId);
        public Task CreateLesson(CreateLessonRequest createLessonRequest);
        public Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest);
        public Task<bool> DeleteLesson(int id);
    }

    public class LessonRepository : ILessonRepository
    {
        public async Task CreateLesson(CreateLessonRequest createLessonRequest)
            => LessonDAO.Instance.CreateLesson(createLessonRequest);

        public async Task<bool> DeleteLesson(int id)
            => await LessonDAO.Instance.DeleteLesson(id);

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId)
            => await LessonDAO.Instance.GetAllLessonsOfCourse(courseId);

        public List<GetLessonResponse> GetListLessonOfCourse(int courseId)
        {
            return LessonDAO.Instance.GetListLessonOfCourse(courseId);
        }

        public async Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest)
            => await LessonDAO.Instance.UpdateLesson(id, updateLessonRequest);
    }
}
