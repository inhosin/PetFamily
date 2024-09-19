using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models;

public class PetPhoto
{
    public Guid Id { get; private set; } // Primary key
    public Guid PetId { get; private set; } // питомец
    public string StoragePath { get; }   // Путь хранения фотографии
    public bool IsMainPhoto { get; private set; }

    private PetPhoto(Guid petId, string storagePath, bool isMainPhoto)
    {
        Id = Guid.NewGuid();
        PetId = petId;
        StoragePath = storagePath;
        IsMainPhoto = isMainPhoto;
    }

    public static Result<PetPhoto> Create(Guid petId, string storagePath, bool isMainPhoto = false)
    {
        if (string.IsNullOrEmpty(storagePath))
            return Result.Failure<PetPhoto>("Сохранить путь к фотографии невозможно");
        if (!storagePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) 
            && !storagePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            return Result.Failure<PetPhoto>("Фотография должна быть в формате jpg или png");
        if (petId == Guid.Empty) return Result.Failure<PetPhoto>("Не указан питомец");
        
        return new PetPhoto(petId, storagePath, isMainPhoto);
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