using CashFlow.Domain.Security.Cryp;
using Moq;

namespace CommonTestUtilities.Cryp;
public class PasswordEncripterBuilder
{
    private readonly Mock<IPasswordCryp> _mock;

    public PasswordEncripterBuilder()
    {
        _mock = new Mock<IPasswordCryp>();

        _mock.Setup(passEncripter => passEncripter.Encrypt(It.IsAny<string>())).Returns("!Aa1MatheusSilva");
    }

    public PasswordEncripterBuilder Verify(string? password)
    {
        if (string.IsNullOrWhiteSpace(password) == false)
        {
            _mock.Setup(passEncripter => passEncripter.Verify(password, It.IsAny<string>())).Returns(true);
        }

        return this;
    }

    public IPasswordCryp Build() => _mock.Object;
}
