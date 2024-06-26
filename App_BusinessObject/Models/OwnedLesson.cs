﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.Models
{
    public class OwnedLesson
    {
        [Key]
        public int OwnedLessonId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        [ForeignKey("LessonId")]
        public int LessonId { get; set; }
        public bool IsOwned { get; set; }
        public bool IsFinished { get; set; }
        public DateTime? FinishedDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
