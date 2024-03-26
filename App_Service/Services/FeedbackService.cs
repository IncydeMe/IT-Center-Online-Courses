using App_BusinessObject.DTOs.Request.Feedback;
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

namespace App_Service.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository = null;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task CreateFeedBack(CreateFeedbackRequest request) => await _feedbackRepository.CreateFeedBack(request);
        public async Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size) => await _feedbackRepository.GetAllFeedbacks(page, size);
        public async Task<bool> ChangeStatus(int feedbackId) => await _feedbackRepository.ChangeStatus(feedbackId);
    }
}
