namespace PetFamily.Domain.Models;

/// <summary>
/// Порода
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
public record BreedInfo(Guid Id, string Name);