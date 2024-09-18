namespace PetFamily.Domain.Models;

public class Pet
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public PetType PetType { get; set; } = default!;
    public string Description { get; set; } = default!;
    public BreedInfo BreedInfo { get; set; } = default!;
    public string Color { get; set; } = default!;
    public string HealthInfo { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string TelephoneNumber { get; set; } = default!;
    public float Weight { get; set; }
    public float Height { get; set; }
    public bool IsCastrated { get; set; }
    public DateTime BirthdayTime { get; set; }
    public bool IsVaccinated { get; set; }
    public HelpStatus HelpStatus { get; set; }
    public List<Requisite> Requisites { get; set; } = default!;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}