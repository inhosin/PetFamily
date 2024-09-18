namespace PetFamily.Domain.Models;

/// <summary>
/// Соц.сеть
/// </summary>
/// <param name="Name"></param>
/// <param name="Url"></param>
public record SocialNetwork(
    string Name,        // Название социальной сети
    string Url         // Ссылка на профиль в соцсети
);