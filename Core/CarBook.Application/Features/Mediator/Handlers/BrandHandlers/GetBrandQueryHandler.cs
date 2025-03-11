using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetAllAsync();
            return brands.Select(brand => new GetBrandQueryResult
            {
                BrandID = brand.BrandID,
                Name = brand.Name
            }).ToList();
        }
    }
}
