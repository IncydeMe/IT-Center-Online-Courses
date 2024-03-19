using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
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
    public class LessonRepository : ILessonRepository
    {
        public async Task CreateLesson(CreateLessonRequest createLessonRequest)
            => await LessonDAO.Instance.CreateLesson(createLessonRequest);

        public async Task<bool> DeleteLesson(int id)
            => await LessonDAO.Instance.DeleteLesson(id);

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId)
            => await LessonDAO.Instance.GetAllLessonsOfCourse(courseId);

        public async Task<List<GetLessonResponse>> GetListLessonOfCourse(int courseId) => await LessonDAO.Instance.GetListLessonOfCourse(courseId);

        public async Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest)
            => await LessonDAO.Instance.UpdateLesson(id, updateLessonRequest);
    }
}
