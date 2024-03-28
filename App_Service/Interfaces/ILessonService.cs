using App_BusinessObject.DTOs.Request.Lesson;
using App_BusinessObject.DTOs.Response.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface ILessonService
    {
        public Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId);
        public Task CreateLesson(CreateLessonRequest createLessonRequest);
        public Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest);
        public Task<bool> DeleteLesson(int id);
    }
}
