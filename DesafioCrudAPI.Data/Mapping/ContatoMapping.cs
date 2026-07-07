using DesafioCrudAPI.Entidade.Contato;
using Microsoft.EntityFrameworkCore;

namespace DesafioCrudAPI.Data.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeContato)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                  .IsRequired()
                  .HasMaxLength(150);

            builder.Property(c => c.Sexo)
                   .IsRequired();

            builder.Property(c => c.DataNascimento)
                   .IsRequired();

            builder.Property(c => c.Idade)
                   .IsRequired();
        }
    }
}
