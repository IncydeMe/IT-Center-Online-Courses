using App_BusinessObject.DTOs.Request.OwnedLesson;
using App_BusinessObject.DTOs.Response.OwnedLesson;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Interfaces
{
    public interface IOwnedLessonRepository
    {
        public Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size);
        public Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson);
        public Task<bool> ChangeOwnedLessonStatus(int id);
        public Task<List<GetOwnedLessonResponse>> GetOwnedLessonsList(int accountId);
    }
}
