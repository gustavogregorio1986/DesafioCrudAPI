using DesafioCrudAPI.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCrudAPI.Entidade.Contato
{
    public class Contato
    {
        public int Id { get; set; }

        public string NomeContato { get; set; }

        public string Email { get; set; }

        public EnumSexo Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }
    }
}
