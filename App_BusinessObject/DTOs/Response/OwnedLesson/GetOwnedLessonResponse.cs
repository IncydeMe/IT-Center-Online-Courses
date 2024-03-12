using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.OwnedLesson
{
    public class GetOwnedLessonResponse
    {
        public int OwnedLessonId { get; set; }
        public int LessonId { get; set; }
        public int AccountId { get; set; }
        public bool IsOwned { get; set; }
        public bool IsFinished { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
