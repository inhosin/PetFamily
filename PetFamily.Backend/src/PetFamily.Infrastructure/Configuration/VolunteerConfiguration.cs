using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Models;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configuration;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(x => x.Id); // primary key
        builder.Property(x => x.Id).HasConversion(id => id.Value, value => VolunteerId.Create(value));
        builder.Property(x => x.FullName).ConfigureString(Constants.StringLengthMedium);
        builder.Property(x => x.Email).ConfigureString(Constants.StringLengthMedium);
        builder.Property(x => x.Description).ConfigureString(Constants.StringLengthLong);
        builder.Property(x => x.PhoneNumber).ConfigureString();
        builder.Property(x => x.YearsOfExperience);
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("pet_id")
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.OwnsOne(v => v.SocialNetworks, d =>
        {
            d.ToJson();
            d.OwnsMany(s => s.Data, s =>
            {
                s.Property(n => n.Name).ConfigureString();
                s.Property(n => n.Link).ConfigureString(Constants.StringLengthMedium);
            });
        });
        
        builder.OwnsOne(v => v.Payments, d =>
        {
            d.ToJson();
            d.OwnsMany(p => p.Data, i =>
            {
                i.Property(n => n.Name).ConfigureString();
                i.Property(n => n.Description).ConfigureString(Constants.StringLengthMedium);
            });
        });
    }
}