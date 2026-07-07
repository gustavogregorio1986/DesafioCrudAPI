using DesafioCrudAPI.Data.Mapping;
using DesafioCrudAPI.Entidade.Contato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Data.Contexto
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você aplica o mapeamento da entidade Contato
            modelBuilder.ApplyConfiguration(new ContatoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
