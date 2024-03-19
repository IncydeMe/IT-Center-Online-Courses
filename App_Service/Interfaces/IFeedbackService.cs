using App_BusinessObject.DTOs.Request.Feedback;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IFeedbackService
    {
        public void CreateFeedBack(CreateFeedbackRequest request);
        public Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size);
        public Task<bool> ChangeStatus(int feedbackId);
    }
}
