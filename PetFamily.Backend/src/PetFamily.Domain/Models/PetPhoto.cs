using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models;

public class PetPhoto : EntityBase<PetPhotoId>
{
    public PetId PetId { get; }
    public Pet Pet { get; }
    public string StoragePath { get; }   // Путь хранения фотографии
    public bool IsMainPhoto { get; private set; }

    private PetPhoto(PetPhotoId id, PetId petId, string storagePath, bool isMainPhoto) : base(id)
    {
        PetId = petId;
        StoragePath = storagePath;
        IsMainPhoto = isMainPhoto;
    }

    public static Result<PetPhoto> Create(PetId petId, string storagePath, bool isMainPhoto = false)
    {
        if (string.IsNullOrEmpty(storagePath))
            return Result.Failure<PetPhoto>("Сохранить путь к фотографии невозможно");
        if (!storagePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) 
            && !storagePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            return Result.Failure<PetPhoto>("Фотография должна быть в формате jpg или png");
        
        return new PetPhoto(PetPhotoId.CreateNew(), petId, storagePath, isMainPhoto);
    }

    /// <summary>
    /// Устанавливает фотографию как главную или нет
    /// </summary>
    /// <param name="isMainPhoto"></param>
    public void SetAsMainPhoto(bool isMainPhoto)
    {
        IsMainPhoto = isMainPhoto; 
    }
}