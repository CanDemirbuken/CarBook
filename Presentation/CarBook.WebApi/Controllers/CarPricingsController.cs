using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class CarPricingsController : BaseController
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingWithCars() => Ok(await _mediator.Send(new GetCarPricingWithCarQuery()));
    }
}
