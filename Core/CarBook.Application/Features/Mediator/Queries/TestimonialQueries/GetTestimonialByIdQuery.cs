using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public int TestimonialId { get; set; }

        public GetTestimonialByIdQuery(int testimonialId)
        {
            TestimonialId = testimonialId;
        }
    }
}
