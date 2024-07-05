namespace Domain.Common.ValueObjects;

using Domain.Common.Models;

public class Image : ValueObject
{
    private Image(string url) => this.Url = url;
    
    public string Url { get; }

    public Image Create(string url) => new Image(url);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Url;
    }
}