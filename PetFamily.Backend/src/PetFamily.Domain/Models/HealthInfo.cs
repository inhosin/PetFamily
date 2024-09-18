using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models;

/// <summary>
/// Информация о здоровье питомца
/// </summary>
public class HealthInfo
{
    public bool IsCastrated { get; init; }
    public bool IsVaccinated { get; init; }
    public float Weight { get; private set; } // Вес в килограммах
    public float Height { get; private set; }// Рост в сантиметрах
    public string AdditionalInfo { get; init; } = default!; // Дополнительная информация о здоровье

    public static Result<HealthInfo> Create(bool isCastrated, bool isVaccinated, float weight, float height, string additionalInfo)
    {
        if (weight < 0 || height < 0) return Result.Failure<HealthInfo>("Weight or height cannot be negative");
        
        return new HealthInfo
        {
            IsCastrated = isCastrated,
            IsVaccinated = isVaccinated,
            Weight = weight,
            Height = height,
            AdditionalInfo = additionalInfo
        };
    }
}