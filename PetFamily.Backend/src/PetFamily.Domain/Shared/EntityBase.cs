namespace PetFamily.Domain.Shared;
public abstract class EntityBase<T>(T id)
{
    public T Id { get; private set;} = id;
}