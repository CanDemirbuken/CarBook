using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int SocialMediaId { get; set; }

        public GetSocialMediaByIdQuery(int socialMediaId)
        {
            SocialMediaId = socialMediaId;
        }
    }
}
