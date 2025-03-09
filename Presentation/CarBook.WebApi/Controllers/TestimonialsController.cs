using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class TestimonialsController : BaseController
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList() => Ok(await _mediator.Send(new GetTestimonialQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> TestimonialById(int id) => Ok(await _mediator.Send(new GetTestimonialByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans ekleme işlemi tamamlandı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans güncelleme işlemi tamamlandı.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans silme işlemi tamamlandı.");
        }
    }
}
