namespace PetFamily.Domain.Models;

public class HealthInfo
{
    public Guid PetId { get; init; }
    public bool IsCastrated { get; init; }
    public bool IsVaccinated { get; init; }
    public string AdditionalInfo { get; init; } // Дополнительная информация о здоровье

    public static HealthInfo Create(Guid petId, bool isCastrated, bool isVaccinated, string additionalInfo)
    {
        return new HealthInfo
        {
            PetId = petId,
            IsCastrated = isCastrated,
            IsVaccinated = isVaccinated,
            AdditionalInfo = additionalInfo
        };
    }
}