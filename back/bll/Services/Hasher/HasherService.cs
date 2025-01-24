using meero.entity;
using Microsoft.AspNetCore.Identity;
namespace meero.bll.Service;

public class HasherService(IPasswordHasher<ApplicationUser> passwordHasher) : IHashService
{

    private readonly IPasswordHasher<ApplicationUser> _passwordHasher = passwordHasher;

    public string HashPassword(ApplicationUser user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }

    public bool VerifyPassword(ApplicationUser user, string hashedPassword, string password){
        var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}