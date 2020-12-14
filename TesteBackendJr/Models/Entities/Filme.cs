using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendJr.Models.Entities

{
    public class Filme
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double PrecoLocacao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Locacao> Locacaos { get; set; }

        public Filme(string nome, int estoque, double precoLocacao, bool ativo)
        {
            Nome = nome;
            Estoque = estoque;
            PrecoLocacao = precoLocacao;
            Ativo = ativo;
        }
    }
}
