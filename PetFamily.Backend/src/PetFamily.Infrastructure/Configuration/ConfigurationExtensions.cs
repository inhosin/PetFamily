using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration;

internal static class ConfigurationExtensions
{
    public static PropertyBuilder<TProperty> ConfigureString<TProperty>(this PropertyBuilder<TProperty> builder,
        int maxLen = Constants.StringLengthSmall)
    {
        return builder.IsRequired().HasMaxLength(maxLen);
    }
    
    public static ComplexTypePropertyBuilder<TProperty> ConfigureString<TProperty>(this ComplexTypePropertyBuilder<TProperty> builder,
        int maxLen = Constants.StringLengthSmall)
    {
        return builder.IsRequired().HasMaxLength(maxLen);
    }
}