﻿using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.AboutID);
            return new GetAboutByIdQueryResult
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }
    }
}
