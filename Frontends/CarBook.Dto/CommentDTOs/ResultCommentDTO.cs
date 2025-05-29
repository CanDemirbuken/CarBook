namespace CarBook.Dto.CommentDTOs
{
    public class ResultCommentDTO
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogID { get; set; }
    }
}
