namespace SRP.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int ISO { get; set; }
    public string? A3 { get; set; }
    public string? A2 { get; set; }
    public int DialingCode { get; set; }

    public ICollection<Province> Provinces { get; set; } = new List<Province>();
}
