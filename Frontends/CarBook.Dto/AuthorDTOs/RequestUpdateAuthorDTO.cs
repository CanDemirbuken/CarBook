namespace CarBook.Dto.AuthorDTOs
{
    public class RequestUpdateAuthorDTO
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
