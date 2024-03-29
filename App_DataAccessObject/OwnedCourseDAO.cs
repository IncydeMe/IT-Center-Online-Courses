using AutoMapper;
using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_BusinessObject.DTOs.Response.OwnedCourse;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App_BusinessObject
{
    public class OwnedCourseDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static OwnedCourseDAO instance;
        public static OwnedCourseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OwnedCourseDAO();
                }
                return instance;
            }
        }

        public OwnedCourseDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OwnedCourseMapper())).CreateMapper().ConfigurationProvider);
        }

        public async Task CreateOwnedCourse(CreateOwnedCourseRequest newOwnedCourse)
        {
            _dbContext.OwnedCourses.Add(_mapper.Map<OwnedCourse>(newOwnedCourse));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IPaginate<GetOwnedCourseResponse>> GetOwnedCourse(int accountId, int page, int size)
        {
            IPaginate<GetOwnedCourseResponse> ownedCourseList = await _dbContext.OwnedCourses.Select(x => new GetOwnedCourseResponse
            {
                OwnedCourseId = x.OwnedCourseId,
                CourseId = x.CourseId,
                AccountId = x.AccountId,
                IsOwned = x.IsOwned,
                IsFinished = x.IsFinished,
                FinishedDate = (DateTime)x.FinishedDate
            }).Where(x => x.AccountId == accountId).ToPaginateAsync(page, size, 1);
            return ownedCourseList;
        }

        public async Task<bool> ChangeOwnedCourseStatus(int ownedCourseId)
        {
            var ownedCourse = _dbContext.OwnedCourses.FirstOrDefault(x => x.OwnedCourseId == ownedCourseId);
            if (ownedCourse != null)
            {
                ownedCourse.IsFinished = !ownedCourse.IsFinished;
                _dbContext.OwnedCourses.Update(ownedCourse);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Lesson>> GetLessonInOwnedCourse(int courseId)
        {
            return await _dbContext.Lessons.Where(x => x.CourseId == courseId).ToListAsync();
        }
    }
}
