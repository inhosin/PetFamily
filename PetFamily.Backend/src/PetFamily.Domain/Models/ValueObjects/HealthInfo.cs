namespace PetFamily.Domain.Models.ValueObjects;

/// <summary>
/// Информация о здоровье питомца
/// </summary>
public record HealthInfo(bool IsCastrated, bool IsVaccinated, float Weight, float Height, string AdditionalInfo);