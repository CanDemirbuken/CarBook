using CarBook.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int ServiceId { get; set; }

        public GetServiceByIdQuery(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
