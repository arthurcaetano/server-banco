using DFC.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DFC.Domain;

namespace DFC.Infra.Data.Mappings
{
    public class MovimentacaoMapping : EntityTypeConfiguration<Movimentacao>
    {
        public override void Map(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.Property(e => e.Valor)
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Movimentacoes");

            builder.HasOne(e => e.Conta).WithMany(e => e.Movimentacao).HasForeignKey(p => p.IdConta).IsRequired();
        }
    }
}