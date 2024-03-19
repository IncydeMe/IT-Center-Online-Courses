using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.OwnedCourse
{
    public class GetOwnedCourseResponse
    {
        public int OwnedCourseId { get; set; }
        public int CourseId { get; set; }
        public int AccountId { get; set; }
        public bool IsOwned { get; set; }
        public bool IsFinished { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
