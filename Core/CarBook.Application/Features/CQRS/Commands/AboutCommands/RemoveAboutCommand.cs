namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public int AboutID { get; set; }

        public RemoveAboutCommand(int aboutID)
        {
            AboutID = aboutID;
        }
    }
}
