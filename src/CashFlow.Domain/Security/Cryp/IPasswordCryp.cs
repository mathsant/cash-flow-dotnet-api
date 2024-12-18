﻿namespace CashFlow.Domain.Security.Cryp;
public interface IPasswordCryp
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}
