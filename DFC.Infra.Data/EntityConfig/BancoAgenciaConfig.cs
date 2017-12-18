using DFC.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFC.Infra.Data.EntityConfig
{
    public class BancoAgenciaConfig
    {
        public BancoAgenciaConfig(EntityTypeBuilder<BancoAgencia> entity)
        {
            entity.HasOne(p => p.Banco)
                .WithMany(b => b.Agencias)
                .HasForeignKey(p => p.IdBanco);
        }
    }
}