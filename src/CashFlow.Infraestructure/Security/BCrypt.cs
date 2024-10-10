using CashFlow.Domain.Security.Cryp;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infraestructure.Security;
internal class BCrypt : IPasswordCryp
{
    public string Encrypt(string password)
    {
        string passHash = BC.HashPassword(password);

        return passHash;
    }
}
