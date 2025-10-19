using Ulid = System.Ulid;

namespace Vibora.Domain.Entities;
public class User
{
    public Ulid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(string name, string email, string passwordHash)
    {
        Id = Ulid.NewUlid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }
    private User() { }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("O nome do usuário é obrigatório.");
        if (string.IsNullOrWhiteSpace(Email))
            throw new ArgumentException("O e-mail do usuário é obrigatório.");
    }
}

