using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public class OwnedCourseService : IOwnedCourseService
    {
        private readonly IOwnedCourseRepository _ownedCourseRepository;
        public OwnedCourseService(IOwnedCourseRepository ownedCourseRepository)
        {
            _ownedCourseRepository = ownedCourseRepository;
        }

        public async Task<bool> ChangeOwnedCourseStatus(int id) => await _ownedCourseRepository.ChangeOwnedCourseStatus(id);

        public async Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest) => await _ownedCourseRepository.CreateOwnedCourse(createOwnedCourseRequest);

        public async Task<IPaginate<GetOwnedCourseResponse>> GetOwnedCourse(int accountId, int page, int size) => await _ownedCourseRepository.GetAllOwnedCourse(accountId, page, size);

        public async Task<List<Lesson>> GetLessonInOwnedCourse(int courseId) => await _ownedCourseRepository.GetLessonInOwnedCourse(courseId);
    }
}
