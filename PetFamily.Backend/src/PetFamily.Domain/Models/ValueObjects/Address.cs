using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ValueObjects;

/// <summary>
/// Информация об адресе
/// </summary>
public class Address
{
    public string Street { get; } // Улица
    public string City { get; } // Город
    public string State { get; } // Страна/регион
    public string ZipCode { get; } // Индекс
    
    private Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public static Result<Address, string> Create(string street, string city, string state, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            return "Street cannot be empty";

        if (string.IsNullOrWhiteSpace(city))
            return "City cannot be empty";

        if (string.IsNullOrWhiteSpace(state))
            return "State cannot be empty";

        if (string.IsNullOrWhiteSpace(zipCode))
            return "Zip code cannot be empty";

        return new Address(street, city, state, zipCode);
    }
}