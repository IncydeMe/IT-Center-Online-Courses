using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Interfaces
{
    public interface IOwnedCourseRepository
    {
        public Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int courseId, int accountId, int page, int size);
        public Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest);
        public Task<bool> ChangeOwnedCourseStatus(int id);
    }
}
