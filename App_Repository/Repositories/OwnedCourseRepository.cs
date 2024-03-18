using App_BusinessObject;
using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Paginate;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class OwnedCourseRepository : IOwnedCourseRepository
    {
        public async Task<bool> ChangeOwnedCourseStatus(int id)
            => await OwnedCourseDAO.Instance.ChangeOwnedCourseStatus(id);

        public async Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest)
            => OwnedCourseDAO.Instance.CreateOwnedCourse(createOwnedCourseRequest);

        public async Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int courseId, int accountId, int page, int size)
            => await OwnedCourseDAO.Instance.GetOwnedCourse(courseId, accountId, page, size);
    }
}
