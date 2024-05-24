namespace Infrastructure.Persistence;

public sealed class DatabaseOptions
{
    public const string SectionName = "DatabaseOptions";

    public string ConnectionString { get; set; } = string.Empty;
    
    public string DatabaseName { get; set; } = string.Empty;
}