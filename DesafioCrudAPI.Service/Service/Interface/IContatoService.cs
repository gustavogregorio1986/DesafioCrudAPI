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
        Task AdicionarContatoAsync(Contato contato)
    }
}
