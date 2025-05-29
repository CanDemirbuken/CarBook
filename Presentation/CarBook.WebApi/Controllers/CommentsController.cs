using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentRepository.GetById(id);
            return Ok(comment);
        }

        [HttpGet("CommentListByBlog")]
        public IActionResult GetCommentsByBlogId(int id)
        {
            var comments = _commentRepository.GetCommentsByBlogId(id);
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            _commentRepository.Remove(comment);
            return Ok("Yorum başarıyla silindi.");
        }
    }
}
