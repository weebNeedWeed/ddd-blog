namespace Infrastructure.Authentication;

public class JwtOptions
{
    public const string SectionName = "JwtOptions";
    
    public string Issuer { get; set; } = string.Empty;
    
    public string Audience { get; set; } = string.Empty;
    
    public string Key { get; set; } = string.Empty;
    
    public ushort ExpiryMinutes { get; set; }
}