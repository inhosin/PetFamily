using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models;

/// <summary>
/// Волонтёр
/// </summary>
public class Volunteer
{
    public Guid Id { get; init; }                            // Уникальный идентификатор
    public string FullName { get; init; }                    // ФИО
    public string Email { get; init; }                       // Email
    public string Description { get; init; }                 // Общее описание
    public int YearsOfExperience { get; init; }              // Опыт в годах
    public string PhoneNumber { get; init; }                 // Номер телефона
    private List<SocialNetwork> _socialNetworks { get; } = []; // Список социальных сетей
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks; // Список социальных сетей

    private List<PaymentDetail> _paymentInfo { get; } = [];
    public IReadOnlyList<PaymentDetail> PaymentInfo => _paymentInfo; // Список реквизитов для помощи
    private List<Pet> _pets { get; } = [];
    public IReadOnlyList<Pet> Pets => _pets;    // Список питомцев
    
    // Конструктор ef-core
    public Volunteer()
    {
    }

    public static Result<Volunteer> Create(string fullName, string email, string description, int yearsOfExperience, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<Volunteer>("Поле ФИО не может быть пустым");
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Volunteer>("Поле Email не может быть пустым");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volunteer>("Поле Общее описание не может быть пустым");
        if (yearsOfExperience < 0)
            return Result.Failure<Volunteer>("Поле Опыт в годах не может быть пустым");

        return new Volunteer
        {
            Id = Guid.NewGuid(),
            FullName = fullName, 
            Email = email, 
            Description = description, 
            YearsOfExperience = yearsOfExperience,
            PhoneNumber = phoneNumber
        };
    }

    /// <summary>
    /// Метод для добавления социальной сети
    /// </summary>
    /// <param name="socialNetwork"></param>
    public void AddSocialNetwork(SocialNetwork socialNetwork)
    {
        if (!_socialNetworks.Contains(socialNetwork))
            _socialNetworks.Add(socialNetwork);
    }

    /// <summary>
    /// Метод для добавления питомца
    /// </summary>
    /// <param name="pet"></param>
    public void AddPet(Pet pet)
    {
        if (!_pets.Contains(pet))
            _pets.Add(pet);
    }

    /// <summary>
    /// Метод для добавления реквизита для помощи
    /// </summary>
    /// <param name="paymentDetail"></param>
    public void AddPaymentDetail(PaymentDetail paymentDetail)
    {
        if (!_paymentInfo.Contains(paymentDetail))
            _paymentInfo.Add(paymentDetail);
    }

    /// <summary>
    /// Метод для подсчёта количества питомцев, которые нашли дом
    /// </summary>
    /// <returns></returns>
    public int PetsWhoFoundHomeCount()
    {
        return Pets.Count(p => p.HelpStatus is HelpStatus.FoundedHome);
    }

    /// <summary>
    /// Метод для подсчёта количества питомцев, которые ищут дом
    /// </summary>
    /// <returns></returns>
    public int PetsLookingForHomeCount()
    {
        return Pets.Count(p => p.HelpStatus is HelpStatus.LookingForHome);
    }

    /// <summary>
    /// Метод для подсчёта количества питомцев нуждающихся в помощи
    /// </summary>
    /// <returns></returns>
    public int PetsNeedHelpCount()
    {
        return Pets.Count(p => p.HelpStatus == HelpStatus.NeedHelp);
    }
}