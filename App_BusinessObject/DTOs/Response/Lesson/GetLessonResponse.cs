using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Lesson
{
    public class GetLessonResponse
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int CourseId { get; set; }
        public string Type { get; set; }
        public string MaterialUrl { get; set; }
        public bool IsFinished { get; set; }

        public GetLessonResponse()
        {

        }

        public GetLessonResponse(int lessonId, string lessonName, int courseId, string type, string materialUrl, bool isFinished)
        {
            LessonId = lessonId;
            LessonName = lessonName;
            CourseId = courseId;
            Type = type;
            MaterialUrl = materialUrl;
            IsFinished = isFinished;
        }
    }
}
