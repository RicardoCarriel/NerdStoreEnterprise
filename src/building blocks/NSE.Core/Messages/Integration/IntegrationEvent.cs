namespace NSE.Core.Messages.Integration
{
    public abstract class IntegrationEvent : Event
    {

    }

    public class RegisteredUserIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public RegisteredUserIntegrationEvent(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
