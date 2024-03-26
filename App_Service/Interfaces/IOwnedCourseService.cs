using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IOwnedCourseService
    {
        public Task<IPaginate<GetOwnedCourseResponse>> GetOwnedCourse(int accountId, int page, int size);
        public Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest);
        public Task<bool> ChangeOwnedCourseStatus(int id);
    }
}
