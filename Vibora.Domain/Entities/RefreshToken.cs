namespace Vibora.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime Expires { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsRevoked { get; private set; }

    public bool IsActive => !IsRevoked && Expires > DateTime.UtcNow;

    private RefreshToken() { }

    public RefreshToken(Guid userId, string token, DateTime expires, DateTime createdAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedAt = createdAt;
        IsRevoked = false;
    }

    public void Revoke()
    {
        IsRevoked = true;
    }
}

