using Microsoft.AspNetCore.Mvc;

namespace XSSDemoApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Post(int postId)
        {
            var comments = GetComments(postId);
            return View(comments);
        }

        public IActionResult AddComment(string comment)
        {
            // Vulnerabilità di XSS: non escapa l'input dell'utente
            SaveCommentToDatabase(comment);
            return RedirectToAction("Post", new { postId = 1 });
        }
    }
}

