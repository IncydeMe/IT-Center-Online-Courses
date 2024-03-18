using App_BusinessObject;
using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Services
{
    public interface IOwnedCourseRepository
    {
        public Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int courseId, int accountId, int page, int size);
        public void CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest);
        public Task<bool> ChangeOwnedCourseStatus(int id);
    }

    public class OwnedCourseRepository : IOwnedCourseRepository
    {
        public async Task<bool> ChangeOwnedCourseStatus(int id)
            => await OwnedCourseDAO.Instance.ChangeOwnedCourseStatus(id);

        public void CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest)
            => OwnedCourseDAO.Instance.CreateOwnedCourse(createOwnedCourseRequest);

        public async Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int courseId, int accountId, int page, int size)
            => await OwnedCourseDAO.Instance.GetOwnedCourse(courseId, accountId, page, size);
    }
}
