using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    public class CarsController : BaseController
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastFiveCarWithBrandQueryHandler _getLastFiveCarWithBrandQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;

        public CarsController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLastFiveCarWithBrandQueryHandler getLastFiveCarWithBrandQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastFiveCarWithBrandQueryHandler = getLastFiveCarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList() => Ok(await _getCarQueryHandler.Handle());

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand() => Ok(await _getCarWithBrandQueryHandler.Handle());

        [HttpGet("GetLastFiveCarWithBrand")]
        public async Task<IActionResult> GetLastFiveCarWithBrand() => Ok(await _getLastFiveCarWithBrandQueryHandler.Handle());

        [HttpGet("{id}")]
        public async Task<IActionResult> CarById(int id) => Ok(await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araba bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba bilgisi güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba bilgisi silindi.");
        }
    }
}
