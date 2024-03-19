using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.Feedback
{
    public class CreateFeedbackRequest
    {
        public int AccountId { get; set; }
        public int CourseId { get; set; }
        public string Message { get; set; }
    }
}
