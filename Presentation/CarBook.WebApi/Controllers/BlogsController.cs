using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class BlogsController : BaseController
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList() => Ok(await _mediator.Send(new GetBlogQuery()));

        [HttpGet("GetLastThreeBlogWithAuthor")]
        public async Task<IActionResult> GetLastThreeBlogWithAuthor() => Ok(await _mediator.Send(new GetLastThreeBlogWithAuthorQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id) => Ok(await _mediator.Send(new GetBlogByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi.");
        }
    }
}
