using MediatR;


namespace Bank.Application.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string AccountType { get; set; }
    }
}
