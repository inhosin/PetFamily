using System.Text.Json.Serialization;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ValueObjects;

/// <summary>
/// Соц.сеть
/// </summary>
/// <param name="Name"></param>
/// <param name="Link"></param>
public record SocialNetwork
{
    public string Name { get; } = null!;
    public string Link { get; } = null!;

    [JsonConstructor]
    private SocialNetwork(string link, string? name)
    {
        Name = name;
        Link = link;
    }

    public static Result<SocialNetwork> Create(string link, string? name)
    {
        return string.IsNullOrWhiteSpace(link) ? Result.Failure<SocialNetwork>("Link argument should not be empty") : new SocialNetwork(link, name);
    }
}

public record SocialNetworkList
{
    public List<SocialNetwork> Data { get; set; }
}