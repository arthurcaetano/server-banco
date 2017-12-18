using DFC.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DFC.Domain;

namespace DFC.Infra.Data.Mappings
{
    public class ContaMapping : EntityTypeConfiguration<Conta>
    {
        public override void Map(EntityTypeBuilder<Conta> builder)
        {
            builder.Property(e => e.CpfCnpj)
               .HasColumnType("varchar(20)")
               .IsRequired();

            builder.Property(e => e.Titular)
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Contas");

            builder.HasOne(e => e.Agencia).WithMany(e => e.Contas).HasForeignKey(p => p.IdBancoAgencia).IsRequired();

            builder.HasMany(e => e.Movimentacao)
                .WithOne(e => e.Conta)
                .HasForeignKey(e => e.IdConta)
                .IsRequired(false);
        }
    }
}