using DesafioCrudAPI.Entidade.Contato;
using DesafioCrudAPI.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Repository.Repository.Interface
{
    public interface IContatoRepository
    {
        Task AdicionarAsync(Contato contato);
        Task<Contato?> ObterPorIdAsync(int id);
        Task<List<Contato>> ListarTodosAsync();
        Task AtualizarAsync(Contato contato);
        Task RemoverAsync(int id);

        // Exemplos de consultas com LINQ
        Task<List<Contato>> BuscarPorNomeAsync(string nome);
        Task<List<Contato>> BuscarPorSexoAsync(EnumSexo sexo);
    }
}
