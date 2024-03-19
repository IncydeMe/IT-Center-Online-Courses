using App_BusinessObject.DTOs.Request.Feedback;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject
{
    public class FeedbackDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private static FeedbackDAO instance = null;

        public static FeedbackDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackDAO();
                }
                return instance;
            }

        }

        public FeedbackDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
        }

        public async void CreateFeedBack(CreateFeedbackRequest request)
        {
            Feedback createdFeedback = new Feedback
            {
                FeedbackId = 0,
                CourseId = request.CourseId,
                AccountId = request.AccountId,
                Message = request.Message,
                Status = true
            };

            _dbContext.Feedbacks.Add(createdFeedback);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size)
        {
            IPaginate<Feedback> feedbackList = await _dbContext.Feedbacks.Select(x => new Feedback
            {
                FeedbackId = x.FeedbackId,
                AccountId = x.AccountId,
                CourseId = x.CourseId,
                Message = x.Message,
                Status = x.Status
            }).ToPaginateAsync(page, size, 1);
            return feedbackList;
        }

        public async Task<bool> ChangeStatus(int feedbackId)
        {
            Feedback feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(x => x.FeedbackId == feedbackId);

            if(feedback != null)
            {
                _dbContext.Entry(feedback).Property("Status").CurrentValue = !feedback.Status;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
