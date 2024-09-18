namespace PetFamily.Domain.Models;

public record PaymentDetail(
    string Name,       // Название реквизита (например, банк, система переводов)
    string Description // Описание того, как сделать перевод
    );