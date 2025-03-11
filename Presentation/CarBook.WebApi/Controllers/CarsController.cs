using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class CarsController : BaseController
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList() => Ok(await _mediator.Send(new GetCarQuery()));

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand() => Ok(await _mediator.Send(new GetCarWithBrandQuery()));

        [HttpGet("GetLastFiveCarWithBrand")]
        public async Task<IActionResult> GetLastFiveCarWithBrand() => Ok(await _mediator.Send(new GetLastFiveCarWithBrandQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> CarById(int id) => Ok(await _mediator.Send(new GetCarByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba bilgisi güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok("Araba bilgisi silindi.");
        }
    }
}
