using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
