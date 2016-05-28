namespace ProjectSample.Core.Infrastructure.Security
{
    public interface ICryptoService
    {
        string HashPassword(string password);
        bool VerifyHash(string hash, string password);
    }
}