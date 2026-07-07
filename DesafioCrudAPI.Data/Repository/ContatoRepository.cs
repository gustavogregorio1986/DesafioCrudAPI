using DesafioCrudAPI.Data.Contexto;
using DesafioCrudAPI.Data.Repository.Interface;
using DesafioCrudAPI.Entidade.Contato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AplicationContext _context;

        public ContatoRepository(AplicationContext context)
        {
            _context = context;
        }


        public async Task AtualizarAsync(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contato>> ListarTodosAsync()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<Contato> ObterPorIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task RemoverAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }
    }
}
