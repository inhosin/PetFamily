using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

public class PetPhotoId: Id<Guid>
{
    private PetPhotoId(Guid value) : base(value)
    {
    }
    /// <summary>
    /// Create a new PetPhotoId
    /// </summary>
    public static PetPhotoId NewId() => new(Guid.NewGuid());
    /// <summary>
    /// Create an empty PetPhotoId
    /// </summary>
    /// <returns></returns>
    public static PetPhotoId Empty() => new(Guid.Empty);
}