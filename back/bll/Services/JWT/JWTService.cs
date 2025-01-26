using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using meero.entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace meero.bll.Service;

public class JWTService : IJWTService
{
    private readonly string? _secretKey;
    private readonly string? _issuer;
    private readonly string? _audience;

    public JWTService(IConfiguration configuration)
    {
        _secretKey = configuration["JWT_KEY"];
        _issuer = configuration["JWT_ISSUER"];
        _audience = configuration["JWT_AUDIENCE"];
    
    }

    public string generate(ApplicationUser applicationUser)
    {
        if (_secretKey == null)
        {
            throw new ArgumentNullException(_secretKey, "The 'JWT_SECRET' configuration value is missing.");
        }
        if (_issuer == null)
        {
            throw new ArgumentNullException(_issuer, "The 'JWT_ISSUER' configuration value is missing.");
        }
        if (_audience == null)
        {
            throw new ArgumentNullException(_audience, "The 'JWT_AUDIENCE' configuration value is missing.");
        }

        string? name = applicationUser.Name;
        if (name == null){
            name = "";
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        // Define token claims
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
                new Claim(ClaimTypes.Role, applicationUser.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1), 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _issuer,
            Audience = _audience

        };

        // Generate Token
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public ApplicationUser validate(string token)
    {

        if (_secretKey == null)
        {
            throw new ArgumentNullException(_secretKey, "The 'JWT_SECRET' configuration value is missing.");
        }
        if (_issuer == null)
        {
            throw new ArgumentNullException(_issuer, "The 'JWT_ISSUER' configuration value is missing.");
        }
        if (_audience == null)
        {
            throw new ArgumentNullException(_audience, "The 'JWT_AUDIENCE' configuration value is missing.");
        }

        try
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            SecurityToken? validatedToken;
            ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            if (validatedToken is not JwtSecurityToken jwtToken)
            {
                throw new InvalidTokenException();
            }

            Claim? userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            Claim? nameClaim = principal.FindFirst(ClaimTypes.Name);
            Claim? roleClaim = principal.FindFirst(ClaimTypes.Role);

            if (userIdClaim == null || nameClaim == null || roleClaim == null)
            {
                throw new InvalidTokenException();
            }

            ApplicationUser user = new ApplicationUser
            {
                Id = int.Parse(userIdClaim.Value),
                Name = nameClaim.Value,
                Role = Enum.TryParse<ERole>(roleClaim.Value, true, out ERole role)
                    ? role
                    : throw new InvalidTokenException()
            };

            return user;
        }
        catch (SecurityTokenException)
        {
            throw new InvalidTokenException();
        }
    }
}