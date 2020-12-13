using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendJr.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Locacao> Locacaos { get; set; }

        public Cliente(string nome, long cPF, bool ativo)
        {
            Nome = nome;
            CPF = cPF;
            Ativo = ativo;
        }

        public Cliente()
        {
        }
    }
}
