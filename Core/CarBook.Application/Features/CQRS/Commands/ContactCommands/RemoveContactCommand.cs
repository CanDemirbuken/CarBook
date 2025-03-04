namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public int ContactID { get; set; }

        public RemoveContactCommand(int contactID)
        {
            ContactID = contactID;
        }
    }
}
