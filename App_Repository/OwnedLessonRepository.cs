using App_BusinessObject.DTOs.Request.OwnedLesson;
using App_BusinessObject.DTOs.Response.OwnedLesson;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface IOwnedLessonRepository
    {
        public Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size);
        public Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson);
        public Task<bool> ChangeOwnedLessonStatus(int id);
    }

    public class OwnedLessonRepository : IOwnedLessonRepository
    {
        public async Task<bool> ChangeOwnedLessonStatus(int id)
            => await OwnedLessonDAO.Instance.ChangeOwnedLessonStatus(id);

        public async Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson)
            => await OwnedLessonDAO.Instance.CreateOwnedLesson(newOwnedLesson);

        public async Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size)
            => await OwnedLessonDAO.Instance.GetOwnedLesson(accountId, page, size);
    }
}
