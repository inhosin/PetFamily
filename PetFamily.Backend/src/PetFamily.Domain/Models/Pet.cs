using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models;

/// <summary>
/// Питомец
/// </summary>
public class Pet
{
    public Guid Id { get; private set; } = Guid.NewGuid(); // Уникальный идентификатор
    public string Name { get; private set; } = default!; // Кличка
    public string Species { get; private set; } = default!; // Вид (например, собака, кошка)
    public string Description { get; private set; } = default!; // Общее описание
    public BreedInfo BreedInfo { get; private set; } = default!; // Порода
    public string Color { get; private set; } = default!; // Окрас
    public HealthInfo Health { get; private set; } = default!; // Информация о здоровье питомца
    public Address Address { get; private set; } = default!; // Адрес, где находится питомец
    public string OwnerPhoneNumber { get; private set; } = default!;// Номер телефона владельца
    public DateTime DateOfBirth { get; private set; } // Дата рождения питомца
    public HelpStatus HelpStatus { get; private set; } = HelpStatus.NeedHelp;// Статус помощи (нуждается в помощи, ищет дом, нашел дом)
    private readonly List<PaymentDetail> _paymentInfo = []; // Реквизиты для помощи
    public IReadOnlyList<PaymentDetail> PaymentInfo  => _paymentInfo; // Реквизиты для помощи
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow; // Дата создания

    // ef
    public Pet()
    {
        
    }

    public static Result<Pet> Create(string name, string species, string description, BreedInfo? breedInfo, string color,
        HealthInfo? healthInfo, Address? address, string ownerPhoneNumber, DateTime dateOfBirth)
    {
        if (string.IsNullOrEmpty(name)) return Result.Failure<Pet>("Name is required");
        if (string.IsNullOrEmpty(species)) return Result.Failure<Pet>("Species is required");
        if (string.IsNullOrEmpty(description)) return Result.Failure<Pet>("Description is required");
        if (breedInfo is null) return Result.Failure<Pet>("BreedInfo is required");
        if (string.IsNullOrEmpty(color)) return Result.Failure<Pet>("Color is required");
        if (healthInfo is null) return Result.Failure<Pet>("HealthInfo is required");
        if (address is null) return Result.Failure<Pet>("Address is required");
        
        return new Pet
        {
            Id = Guid.NewGuid(),
            Name = name,
            Species = species,
            Description = description,
            BreedInfo = breedInfo,
            Color = color,
            Health = healthInfo,
            Address = address,
            OwnerPhoneNumber = ownerPhoneNumber,
            DateOfBirth = dateOfBirth,
            CreateAt = DateTime.UtcNow
        };
    }
    
    public void UpdateStatus(HelpStatus helpStatus)
    {
        HelpStatus = helpStatus;
    }
    public void AddPayment(PaymentDetail paymentDetail)
    {
        _paymentInfo.Add(paymentDetail);
    }
}

