using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        builder.HasKey(x => x.Id); // primary key
        builder.Property(x => x.Name).ConfigureString();
        builder.Property(x => x.Description).ConfigureString(Constants.StringLengthLong);
        builder.Property(x => x.Color).ConfigureString();
        builder.Property(x => x.Species).ConfigureString();
        builder.Property(x => x.OwnerPhoneNumber).ConfigureString();
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.Property(e => e.CreateAt).IsRequired();
        builder.Property(x => x.HelpStatus).IsRequired();

        builder.ComplexProperty(x => x.BreedInfo, bi =>
        {
            bi.Property(i => i.Id).IsRequired();
            bi.Property(i => i.Name).ConfigureString();
        });

        builder.ComplexProperty(x => x.Health, hi =>
        {
            hi.Property(i => i.Height).IsRequired();
            hi.Property(i => i.Weight).IsRequired();
            hi.Property(i => i.AdditionalInfo).ConfigureString();
            hi.Property(i => i.IsCastrated).IsRequired();
            hi.Property(i => i.IsVaccinated).IsRequired();
        });
        
        builder.ComplexProperty(x => x.Address, a =>
        {
            a.Property(i => i.ZipCode).ConfigureString();
            a.Property(i => i.City).ConfigureString(Constants.StringLengthMedium);
            a.Property(i => i.State).ConfigureString(Constants.StringLengthMedium);
            a.Property(i => i.Street).ConfigureString(Constants.StringLengthMedium);
        });
        
        builder.HasMany(e => e.Photos)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction).HasForeignKey("pet_id");
    }
}