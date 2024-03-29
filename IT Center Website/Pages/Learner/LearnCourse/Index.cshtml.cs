using App_BusinessObject.Models;
using App_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Learner.LearnCourse
{
    public class IndexModel : PageModel
    {
        private readonly IOwnedCourseService _ownedCourseService;
        private readonly IOwnedLessonService _ownedlessonService;
        private readonly ILessonService _lessonService;

        public IndexModel(IOwnedCourseService ownedCourseService, IOwnedLessonService ownedLessonService,
            ILessonService lessonService)
        {
            _ownedCourseService = ownedCourseService;
            _ownedlessonService = ownedLessonService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty]
        public string materialUrl { get; set; }

        [BindProperty]
        public List<Lesson> Lessons { get; set; }

        public async Task OnGetAsync()
        {
            Lessons = await _ownedCourseService.GetLessonInOwnedCourse(id);
        }
    }
}
