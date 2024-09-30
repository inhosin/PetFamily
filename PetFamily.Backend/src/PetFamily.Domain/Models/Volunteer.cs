using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ValueObjects;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

/// <summary>
/// Волонтёр
/// </summary>
public class Volunteer : EntityBase<VolunteerId>
{
    public string FullName { get; private set; } = default!; // ФИО
    public string Email { get; private set; }  = default!;                      // Email
    public string Description { get; private set; }  = default!;                // Общее описание
    public int YearsOfExperience { get; private set; }              // Опыт в годах
    public string PhoneNumber { get; private set; }  = default!; // Номер телефона
    public SocialNetworkList? SocialNetworks { get; private set; } // Список социальных сетей
    public PaymentInfoList? Payments { get; private set; } // Список реквизитов для помощи
    private readonly List<Pet> _pets = [];
    public IReadOnlyList<Pet> Pets => _pets;                         // Список питомцев
    private Volunteer(VolunteerId id) : base(id) {}
    private Volunteer(
        VolunteerId id,
        string fullName,
        string email,
        string description,
        int yOExperience,
        string phoneNumber,
        IEnumerable<Pet> ownedPets,
        IEnumerable<PaymentInfo> paymentMethods,
        IEnumerable<SocialNetwork> socialNetworks) : base(id)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        YearsOfExperience = yOExperience;
        PhoneNumber = phoneNumber;
        _pets = ownedPets.ToList();
        Payments = new PaymentInfoList { Data = paymentMethods.ToList() };
        SocialNetworks = new SocialNetworkList() { Data = socialNetworks.ToList() };
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
        
        return new Volunteer(VolunteerId.CreateNew())
        {
            FullName = fullName, 
            Email = email, 
            Description = description, 
            YearsOfExperience = yearsOfExperience,
            PhoneNumber = phoneNumber,
            SocialNetworks = new SocialNetworkList() { Data = [] },
            Payments = new PaymentInfoList() { Data = [] },
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
        if (SocialNetworks != null && SocialNetworks.Data.Contains(socialNetwork))
            SocialNetworks.Data.Add(socialNetwork);
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
    /// <param name="payment"></param>
    public void AddPaymentDetail(PaymentInfo payment)
    {
        if (Payments != null && !Payments.Data.Contains(payment))
            Payments.Data.Add(payment);
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