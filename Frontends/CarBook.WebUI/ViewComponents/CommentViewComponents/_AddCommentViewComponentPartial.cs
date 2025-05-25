using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
