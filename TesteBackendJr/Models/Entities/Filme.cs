using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteBackendJr.Models.Entities

{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public double PrecoLocacao { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public ICollection<Locacao> Locacaos { get; set; } = new List<Locacao>();

        public Filme(string nome, int estoque, double precoLocacao, bool ativo)
        {
            Nome = nome;
            Estoque = estoque;
            PrecoLocacao = precoLocacao;
            Ativo = ativo;
        }
        public void AddLocacaos(Locacao locacao)
        {
            Locacaos.Add(locacao);
        }
        public void RemoveLocacaos(Locacao locacao)
        {
            Locacaos.Remove(locacao);
        }
    }
}
