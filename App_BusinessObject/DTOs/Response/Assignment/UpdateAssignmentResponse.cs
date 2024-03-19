using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Assignment
{
    public class UpdateAssignmentResponse
    {
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string Question { get; set; }
        public DateTime Deadline { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }
        public DateTime AssignmentDuration { get; set; }
    }
}
