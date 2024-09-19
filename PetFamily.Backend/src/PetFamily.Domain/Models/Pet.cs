using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ValueObjects;

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
    private readonly List<PetPhoto> _photos = [];
    public IReadOnlyList<PetPhoto> Photos => _photos; // Фотографии
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow; // Дата создания

    // ef
    private Pet()
    {
    }

    public static Result<Pet> Create(string name, string species, string description, BreedInfo? breedInfo, string color,
        HealthInfo? healthInfo, Address? address, string ownerPhoneNumber, DateTime dateOfBirth)
    {
        if (string.IsNullOrEmpty(name)) return Result.Failure<Pet>("Кличка обязательна");
        if (name.Length < 2) return Result.Failure<Pet>("Длина кличка не может быть меньше 2 символов");
        if (string.IsNullOrEmpty(species)) return Result.Failure<Pet>("Вид питомца обязателен");
        if (species.Length < 2) return Result.Failure<Pet>("Длина порода не может быть меньше 2 символов");
        if (string.IsNullOrEmpty(description)) return Result.Failure<Pet>("Описание обязательно");
        if (breedInfo is null) return Result.Failure<Pet>("Порода обязательна");
        if (string.IsNullOrEmpty(color)) return Result.Failure<Pet>("Цвет обязателен");
        if (color.Length < 5) return Result.Failure<Pet>("Длина цвета не может быть меньше 5 символов");
        if (healthInfo is null) return Result.Failure<Pet>("Информация о здоровье питомца обязательна");
        if (address is null) return Result.Failure<Pet>("Адрес обязателен");
        
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
    
    /// <summary>
    /// Добавление фотографии
    /// </summary>
    /// <param name="storagePath"></param>
    /// <param name="isMainPhoto"></param>
    /// <returns></returns>
    public Result AddPhoto(string storagePath, bool isMainPhoto = false)
    {
        if (isMainPhoto)
        {
            // Установим только одну фотографию как главную
            foreach (var photo in _photos)
            {
                photo.SetAsMainPhoto(false);
            }
        }
        var photoResult = PetPhoto.Create(storagePath, isMainPhoto);
        if (photoResult.IsFailure)
            return photoResult;
        
        _photos.Add(photoResult.Value);
        
        return Result.Success();
    }
    
    /// <summary>
    /// Обновить статус помощи
    /// </summary>
    /// <param name="helpStatus"></param>
    public void UpdateStatus(HelpStatus helpStatus)
    {
        HelpStatus = helpStatus;
    }
    
    /// <summary>
    /// Добавить реквизиты для помощи
    /// </summary>
    /// <param name="paymentDetail"></param>
    public void AddPayment(PaymentDetail paymentDetail)
    {
        _paymentInfo.Add(paymentDetail);
    }
}

