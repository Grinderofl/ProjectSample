namespace ProjectSample.Infrastructure.Security.Services.Impl
{
    public class CryptoService : ICryptoService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHash(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}