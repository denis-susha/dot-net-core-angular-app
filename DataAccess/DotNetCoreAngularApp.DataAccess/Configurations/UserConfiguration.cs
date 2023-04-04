using DotNetCoreAngularApp.DataAccess.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCoreAngularApp.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(p => p.UserId);

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(320);

            builder.Property(p => p.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasMaxLength(100);

            builder.Property(p => p.AcceptTerms)
                .IsRequired()
                .HasColumnName("AcceptTerms");

            builder.Property(p => p.ProvinceId)
                .IsRequired()
                .HasColumnName("ProvinceId");

            builder.HasOne(p => p.Province)
                .WithMany(m => m.Users)
                .HasForeignKey(k => k.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
