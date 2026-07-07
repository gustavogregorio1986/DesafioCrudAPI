using DesafioCrudAPI.Entidade.Contato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Data.Repository.Interface
{
    public interface IContatoRepository
    {
        Task<Contato> ObterPorIdAsync(int id);
        Task<List<Contato>> ListarTodosAsync();
        Task AtualizarAsync(Contato contato);
        Task RemoverAsync(int id);

    }
}
