namespace Infrastructure.Authentication;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Domain.AdministratorAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _jwtOptions;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions, IDateTimeProvider dateTimeProvider)
    {
        this._dateTimeProvider = dateTimeProvider;
        this._jwtOptions = jwtOptions.Value;
    }

    public string GenerateToken(Administrator admin)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtOptions.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, admin.Id.Value.ToString()),
        };

        var expiryDate = this._dateTimeProvider.UtcNow.AddMinutes(
            this._jwtOptions.ExpiryMinutes);
        
        var token = new JwtSecurityToken(
            issuer: this._jwtOptions.Issuer,
            audience: this._jwtOptions.Audience,
            claims: claims,
            signingCredentials: credentials,
            expires: expiryDate);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}