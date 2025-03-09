using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _repository.GetByIdAsync(request.TestimonialId);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = testimonial.TestimonialID,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }
}
