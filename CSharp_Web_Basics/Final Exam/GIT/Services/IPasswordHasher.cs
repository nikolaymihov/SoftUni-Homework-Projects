namespace GIT.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
