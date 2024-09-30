using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

public class PetId : Id<Guid>
{
    private PetId(Guid value) : base(value)
    {
    }
    /// <summary>
    /// Create a new PetId
    /// </summary>
    /// <returns></returns>
    public static PetId CreateNew() => new(Guid.NewGuid());
    /// <summary>
    /// Create an empty PetId
    /// </summary>
    /// <returns></returns>
    public static PetId CreateEmpty() => new(Guid.Empty);
    public static PetId Create(Guid value) => new(value);
}