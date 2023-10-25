namespace UnitTestingApp.Functionality;

public record User(string firstName, string lastName)
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string Phone { get; set; } = null!;
    public bool VerifiedEmail { get; set; } = false;
}

public class UserManagement
{
    private readonly List<User> _users = new();
    private int idCounter = 1;
    public IEnumerable<User> AllUsers => _users;

    public void Add(User user)
    {
        _users.Add(user with { Id = idCounter++ });
    }

    public void UpdatePhone(User user)
    {
        var dbUser = _users.First(x => x.Id == user.Id);

        dbUser.Phone = user.Phone;
    }

    public void VerifyEmail(User user)
    {
        var dbUser = _users.First(x => x.Id == user.Id);

        dbUser.VerifiedEmail = true;
    }
}