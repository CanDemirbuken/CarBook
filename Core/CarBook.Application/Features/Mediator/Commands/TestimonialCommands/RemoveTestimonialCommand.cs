using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public int TestimonialId { get; set; }

        public RemoveTestimonialCommand(int testimonialId)
        {
            TestimonialId = testimonialId;
        }
    }
}
