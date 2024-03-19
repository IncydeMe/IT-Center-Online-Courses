using App_BusinessObject.DTOs.Request.Feedback;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public async void CreateFeedBack(CreateFeedbackRequest request) => FeedbackDAO.Instance.CreateFeedBack(request);
        public async Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size) => await FeedbackDAO.Instance.GetAllFeedbacks(page, size);
        public async Task<bool> ChangeStatus(int feedbackId) => await FeedbackDAO.Instance.ChangeStatus(feedbackId);
    }
}
