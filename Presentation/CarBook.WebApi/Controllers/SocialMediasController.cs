using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class SocialMediasController : BaseController
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList() => Ok(await _mediator.Send(new GetSocialMediaQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id) => Ok(await _mediator.Send(new GetSocialMediaByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya ekleme işlemi tamamlandı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya güncelleme işlemi tamamlandı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal medya silme işlemi tamamlandı.");
        }
    }
}
