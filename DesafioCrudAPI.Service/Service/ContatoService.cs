using DesafioCrudAPI.Entidade.Contato;
using DesafioCrudAPI.Repository.Repository.Interface;
using DesafioCrudAPI.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Service.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task AdicionarContatoAsync(Contato contato)
        {
            // Validação da data de nascimento
            if (contato.DataNascimento > DateTime.Today)
                throw new Exception("Data de nascimento não pode ser maior que hoje.");

            // Cálculo da idade
            var idade = CalcularIdade(contato.DataNascimento);

            if (idade <= 0)
                throw new Exception("Idade não pode ser igual a 0.");

            if (idade < 18)
                throw new Exception("Contato deve ser maior de idade (mínimo 18 anos).");

            // Se passou pelas validações, salva no repositório
            await _contatoRepository.AdicionarAsync(contato);
        }

        public async Task<List<Contato>> ListarTodosAsync() =>
            await _contatoRepository.ListarTodosAsync();

        public async Task<Contato?> ObterPorIdAsync(int id) =>
            await _contatoRepository.ObterPorIdAsync(id);

        public async Task AtualizarContatoAsync(Contato contato) =>
            await _contatoRepository.AtualizarAsync(contato);

        public async Task RemoverContatoAsync(int id) =>
            await _contatoRepository.RemoverAsync(id);

        // Método auxiliar para calcular idade corretamente
        private int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;

            // Ajusta se ainda não fez aniversário este ano
            if (dataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
