using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteBackendJr.Models.Entities
{
    public class Cliente //Alteraria de clientes para Locador por causa da Linguagem Ubiqua
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public ICollection<Locacao> Locacaos { get; set; } = new List<Locacao>();

        public Cliente(string nome, long cPF, bool ativo)
        {
            Nome = nome;
            CPF = cPF;
            Ativo = ativo;
        }

        public Cliente()
        {
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
