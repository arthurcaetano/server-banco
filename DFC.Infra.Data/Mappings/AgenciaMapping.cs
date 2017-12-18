using DFC.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DFC.Domain;

namespace DFC.Infra.Data.Mappings
{
    public class AgenciaMapping : EntityTypeConfiguration<BancoAgencia>
    {
        public override void Map(EntityTypeBuilder<BancoAgencia> builder)
        {
            builder.Property(e => e.Codigo)
               .HasColumnType("varchar(6)")
               .IsRequired();

            builder.ToTable("BancoAgencia");

            builder.HasOne(e => e.Banco).WithMany(e => e.Agencias).HasForeignKey(p => p.IdBanco).IsRequired();
        }
    }
}