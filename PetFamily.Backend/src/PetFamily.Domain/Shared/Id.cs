namespace PetFamily.Domain.Shared;

public abstract class Id<T>
{
    public T Value { get; }

    protected Id(T value)
    {
        Value = value;
    }
}