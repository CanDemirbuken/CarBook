﻿namespace CarBook.Dto.BlogDTOs
{
    public class ResultGetBlogByIdDTO
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
    }
}
