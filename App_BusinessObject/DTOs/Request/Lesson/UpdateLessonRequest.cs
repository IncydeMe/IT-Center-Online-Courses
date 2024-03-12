using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.Lesson
{
    public class UpdateLessonRequest
    {
        public string LessonName { get; set; }
        public int CourseId { get; set; }
        public string Type { get; set; }
        public string MaterialUrl { get; set; }
    }
}
