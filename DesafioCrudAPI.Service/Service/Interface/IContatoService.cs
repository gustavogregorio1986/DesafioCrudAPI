using DesafioCrudAPI.Entidade.Contato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Service.Service.Interface
{
    public interface IContatoService
    {
        Task AdicionarContatoAsync(Contato contato);
        Task<List<Contato>> ListarTodosAsync();
        Task<Contato?> ObterPorIdAsync(int id);
        Task AtualizarContatoAsync(Contato contato);
        Task RemoverContatoAsync(int id);
    }
}
