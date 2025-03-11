using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.BannerID);
            banner.Title = request.Title;
            banner.Description = request.Description;
            banner.VideoUrl = request.VideoUrl;
            banner.VideoDescription = request.VideoDescription;

            await _repository.UpdateAsync(banner);
        }
    }
}
