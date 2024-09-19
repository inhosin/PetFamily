using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ValueObjects;

/// <summary>
/// Информация о здоровье питомца
/// </summary>
public class HealthInfo
{
    public bool IsCastrated { get; private set; } // Питомец кастрирован
    public bool IsVaccinated { get; private set; } // Питомец вакцинирован
    public float Weight { get; } // Вес в килограммах
    public float Height { get; } // Рост в сантиметрах
    public string AdditionalInfo { get; private set; } // Дополнительная информация о здоровье

    private HealthInfo(bool isCastrated, bool isVaccinated, float weight, float height, string additionalInfo = default!)
    {
        IsCastrated = isCastrated;
        IsVaccinated = isVaccinated;
        Weight = weight;
        Height = height;
        AdditionalInfo = additionalInfo;
    }

    public static Result<HealthInfo> Create(bool isCastrated, bool isVaccinated, float weight, float height, string additionalInfo)
    {
        if (weight < 0 || height < 0) return Result.Failure<HealthInfo>("Weight or height cannot be negative");
        
        return new HealthInfo(isCastrated, isVaccinated, weight, height, additionalInfo);
    }
    
    /// <summary>
    /// Установить дополнительную информацию о здоровье питомца
    /// </summary>
    /// <param name="additionalInfo"></param>
    public void SetAdditionalInfo(string additionalInfo)
    {
        AdditionalInfo = additionalInfo;
    }

    /// <summary>
    /// ToggleCastrated
    /// </summary>
    /// <param name="isCastrated"></param>
    public void ToggleCastrated(bool isCastrated)
    {
        IsCastrated = isCastrated;
    }
    /// <summary>
    /// ToggleVaccinated
    /// </summary>
    /// <param name="isVaccinated"></param>
    public void ToggleVaccinated(bool isVaccinated)
    {
        IsVaccinated = isVaccinated;
    }
    
}