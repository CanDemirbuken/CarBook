﻿namespace CarBook.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudsByBlogIdQueryResult
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
