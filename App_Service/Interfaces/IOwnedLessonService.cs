using App_BusinessObject.DTOs.Response.OwnedLesson;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IOwnedLessonService
    {
        public Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size);
        public Task CreateOwnedLesson(int courseId, int accountId);
        public Task<bool> ChangeOwnedLessonStatus(int id);
        public Task<float> GetOwnedLessonProgress(int accountId, int courseId);
    }
}
