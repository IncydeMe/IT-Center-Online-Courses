using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.OwnedLesson
{
    public class CreateOwnedLessonRequest
    {
        public int LessonId { get; set; }
        public int AccountId { get; set; }
        public int OwnedCourseId { get; set; }
        [DefaultValue(true)]
        public bool IsOwned { get; set; }
        [DefaultValue(false)]
        public bool IsFinished { get; set; }
    }
}
