using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ValueObjects;

public class PetPhoto
{
    public string StoragePath { get; }   // Путь хранения фотографии
    public bool IsMainPhoto { get; private set; }

    private PetPhoto(string storagePath, bool isMainPhoto)
    {
        StoragePath = storagePath;
        IsMainPhoto = isMainPhoto;
    }

    public static Result<PetPhoto> Create(string storagePath, bool isMainPhoto = false)
    {
        if (string.IsNullOrEmpty(storagePath))
            return Result.Failure<PetPhoto>("Сохранить путь к фотографии невозможно");
        if (!storagePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) && !storagePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            return Result.Failure<PetPhoto>("Фотография должна быть в формате jpg или png");
        
        return new PetPhoto(storagePath, isMainPhoto);
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