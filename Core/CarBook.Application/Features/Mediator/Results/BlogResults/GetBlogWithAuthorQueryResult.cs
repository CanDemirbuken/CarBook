﻿namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogWithAuthorQueryResult
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
