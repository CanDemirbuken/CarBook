namespace CarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public int ContactID { get; set; }

        public GetContactByIdQuery(int contactID)
        {
            ContactID = contactID;
        }
    }
}
