namespace PetFamily.Domain.Models;

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
    public float Weight { get; private set; } // Вес в килограммах
    public float Height { get; private set; }// Рост в сантиметрах
    public DateTime DateOfBirth { get; private set; } // Дата рождения питомца
    public HelpStatus HelpStatus { get; private set; } = HelpStatus.NeedHelp;// Статус помощи (нуждается в помощи, ищет дом, нашел дом)
    private readonly List<PaymentDetail> _paymentInfo = []; // Реквизиты для помощи
    public IReadOnlyList<PaymentDetail> PaymentInfo  => _paymentInfo; // Реквизиты для помощи
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow; // Дата создания

    // ef
    public Pet()
    {
        
    }
    
    public void UpdateStatus(HelpStatus helpStatus)
    {
        HelpStatus = helpStatus;
    }
    public void AddRequisite(PaymentDetail paymentDetail)
    {
        _paymentInfo.Add(paymentDetail);
    }
}

