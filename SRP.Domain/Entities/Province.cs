namespace SRP.Domain.Entities;

public class Province : BaseEntity
{
    public Guid CountryId { get; set; }
    public string? Name { get; set; }
    public Country? Country { get; set; }
}
