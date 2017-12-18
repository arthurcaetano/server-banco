using DFC.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DFC.Domain;

namespace DFC.Infra.Data.Mappings
{
    public class BancoMapping : EntityTypeConfiguration<Banco>
    {
        public override void Map(EntityTypeBuilder<Banco> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Bancos");

            builder.HasMany(e => e.Agencias)
                .WithOne(e => e.Banco)
                .HasForeignKey(e => e.IdBanco)
                .IsRequired(true);
        }
    }
}