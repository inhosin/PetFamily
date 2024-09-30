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
    public static PetPhotoId CreateNew() => new(Guid.NewGuid());
    /// <summary>
    /// Create an empty PetPhotoId
    /// </summary>
    /// <returns></returns>
    public static PetPhotoId CreateEmpty() => new(Guid.Empty);
    public static PetPhotoId Create(Guid value) => new(value);
}