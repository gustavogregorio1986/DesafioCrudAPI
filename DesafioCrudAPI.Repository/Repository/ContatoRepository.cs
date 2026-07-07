using DesafioCrudAPI.Data.Contexto;
using DesafioCrudAPI.Entidade.Contato;
using DesafioCrudAPI.Entidade.Enum;
using DesafioCrudAPI.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;

public class ContatoRepository : IContatoRepository
{
    private readonly AplicationContext _context;

    public ContatoRepository(AplicationContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Contato contato)
    {
        await _context.Contatos.AddAsync(contato);
        await _context.SaveChangesAsync();
    }

    public async Task<Contato?> ObterPorIdAsync(int id)
    {
        return await _context.Contatos
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Contato>> ListarTodosAsync()
    {
        return await _context.Contatos
            .OrderBy(c => c.NomeContato)
            .ToListAsync();
    }

    public async Task AtualizarAsync(Contato contato)
    {
        _context.Contatos.Update(contato);
        await _context.SaveChangesAsync();
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

    // LINQ para buscar por nome
    public async Task<List<Contato>> BuscarPorNomeAsync(string nome)
    {
        return await _context.Contatos
            .Where(c => c.NomeContato.Contains(nome))
            .ToListAsync();
    }

    // LINQ para buscar por sexo
    public async Task<List<Contato>> BuscarPorSexoAsync(EnumSexo sexo)
    {
        return await _context.Contatos
            .Where(c => c.Sexo == sexo)
            .ToListAsync();
    }
}
