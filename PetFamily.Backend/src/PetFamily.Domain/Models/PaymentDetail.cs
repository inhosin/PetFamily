namespace PetFamily.Domain.Models;

/// <summary>
/// Реквизиты оплаты
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public record PaymentDetail(
    string Name,       // Название реквизита (например, банк, система переводов)
    string Description // Описание того, как сделать перевод
    );