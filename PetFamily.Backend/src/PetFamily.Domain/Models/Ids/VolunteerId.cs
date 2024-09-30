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
    public static VolunteerId CreateNew() => new(Guid.NewGuid());
    /// <summary>
    /// Create an empty VolunteerId
    /// </summary>
    /// <returns></returns>
    public static VolunteerId CreateEmpty() => new(Guid.Empty);
    public static VolunteerId Create(Guid value) => new(value);
}