using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration;

public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
{
    public void Configure(EntityTypeBuilder<PetPhoto> builder)
    {
        builder.ToTable("pet_photos");
        builder.HasKey(x => x.Id); // primary key
        builder.Property(x => x.PetId).IsRequired();
        builder.Property(x => x.StoragePath).ConfigureString(Constants.StringLengthMedium);
        builder.Property(x => x.IsMainPhoto).IsRequired();
    }
}