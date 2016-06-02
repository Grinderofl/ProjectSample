namespace ProjectSample.Infrastructure.Security.Services
{
    public interface ICryptoService
    {
        string HashPassword(string password);
        bool VerifyHash(string hash, string password);
    }
}