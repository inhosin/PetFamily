using System.Text.Json.Serialization;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ValueObjects;

/// <summary>
/// Реквизиты оплаты
/// </summary>
/// <param name="Name"></param>
/// <param name="Description"></param>
public record PaymentInfo
{
    public string Name { get; } = null!;
    public string Description { get; } = null!;

    [JsonConstructor]
    private PaymentInfo(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<PaymentInfo> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title)) 
            return Result.Failure<PaymentInfo>("Title should not be empty");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<PaymentInfo>("Description should not be empty");

        return new PaymentInfo(title, description);
    }
}

public record PaymentInfoList
{
    public List<PaymentInfo> Data { get; set; }
}