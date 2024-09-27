using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

public class VolunteerId: Id<Guid>
{
    private VolunteerId(Guid value) : base(value)
    {
    }
    /// <summary>
    /// Create a new VolunteerId
    /// </summary>
    public static VolunteerId NewId() => new(Guid.NewGuid());
    /// <summary>
    /// Create an empty VolunteerId
    /// </summary>
    /// <returns></returns>
    public static VolunteerId Empty() => new(Guid.Empty);
}