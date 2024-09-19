using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ValueObjects;

namespace PetFamily.Domain.Models;

/// <summary>
/// Волонтёр
/// </summary>
public class Volunteer
{
    public Guid Id { get; private set; }                            // Уникальный идентификатор
    public string FullName { get; private set; }                    // ФИО
    public string Email { get; private set; }                       // Email
    public string Description { get; private set; }                 // Общее описание
    public int YearsOfExperience { get; private set; }              // Опыт в годах
    public string PhoneNumber { get; private set; }                 // Номер телефона
    private readonly List<SocialNetwork> _socialNetworks = [];
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks; // Список социальных сетей

    private readonly List<PaymentDetail> _paymentInfo = [];
    public IReadOnlyList<PaymentDetail> PaymentInfo => _paymentInfo; // Список реквизитов для помощи
    private readonly List<Pet> _pets = [];
    public IReadOnlyList<Pet> Pets => _pets;                         // Список питомцев
    
    // Конструктор ef-core
    private Volunteer()
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
    /// Метод для обновления ФИО
    /// </summary>
    /// <param name="fullName"></param>
    /// <returns></returns>
    public Result UpdateFullname(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure("Поле ФИО не может быть пустым");
        if (fullName.Length < 2)
            return Result.Failure("Поле ФИО не может быть пустым");
        FullName = fullName;
        return Result.Success();
    }
    /// <summary>
    /// Метод для обновления Email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public Result UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure("Поле Email не может быть пустым");
        if (email.Length < 2)
            return Result.Failure("Поле Email не может быть пустым");
        if (!email.Contains('@'))
            return Result.Failure("Поле Email не может быть пустым");
        Email = email;
        return Result.Success();
    }

    /// <summary>
    /// Метод для обновления описания
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public Result UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure("Поле Общее описание не может быть пустым");
        if (description.Length < 2)
            return Result.Failure("Поле Общее описание не может быть пустым");
        Description = description;
        return Result.Success();
    }

    /// <summary>
    /// Метод для обновления опыта в годах
    /// </summary>
    /// <param name="yearsOfExperience"></param>
    /// <returns></returns>
    public Result UpdateYearsOfExperience(int yearsOfExperience)
    {
        if (yearsOfExperience < 0)
            return Result.Failure("Поле Опыт в годах не может быть пустым");
        YearsOfExperience = yearsOfExperience;
        return Result.Success();
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
        return _pets.Count(p => p.HelpStatus is HelpStatus.FoundedHome);
    }

    /// <summary>
    /// Метод для подсчёта количества питомцев, которые ищут дом
    /// </summary>
    /// <returns></returns>
    public int PetsLookingForHomeCount()
    {
        return _pets.Count(p => p.HelpStatus is HelpStatus.LookingForHome);
    }

    /// <summary>
    /// Метод для подсчёта количества питомцев нуждающихся в помощи
    /// </summary>
    /// <returns></returns>
    public int PetsNeedHelpCount()
    {
        return _pets.Count(p => p.HelpStatus == HelpStatus.NeedHelp);
    }
}