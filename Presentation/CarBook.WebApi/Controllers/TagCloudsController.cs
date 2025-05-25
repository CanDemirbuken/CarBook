using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class TagCloudsController : BaseController
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTagClouds()
        {
            var result = await _mediator.Send(new GetTagCloudQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetTagCloudByBlogId")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var result = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket bulutu silindi.");
        }
    }
}
