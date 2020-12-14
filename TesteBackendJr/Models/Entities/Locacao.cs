using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendJr.Models.Entities
{
    public class Locacao
    {
        public long Id { get; set; }
        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }

        //Eu faria mais uma tabela para que pudessem ser locados. Mas como no desafio citava, especificamente, "Clientes, Filmes e Locacao" achei melhor só fazer o que foi pedido.
        //public ICollection<Filme> Filmes { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime DataLimiteDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double ValorLocacao { get; set; }
        public double ValorMulta { get; set; }
        public double ValorTotal { get; private set; }

        public void GeraTotal(DateTime date) {
            if (date.CompareTo(DataLimiteDevolucao) <= 0)//devoluão atrasada
            {
                ValorTotal = ValorLocacao;
                return;
            }
            ValorTotal = ValorLocacao + ValorMulta;
        }

        public Locacao(Cliente cliente, Filme filme, double valorLocacao, double valorMulta, DateTime dataLocacao, DateTime dataLimiteDevolucao)
        {
            Cliente = cliente;
            Filme = filme;
            ValorLocacao = valorLocacao;
            ValorMulta = valorMulta;
            DataLocacao = dataLocacao;
            DataLimiteDevolucao = dataLimiteDevolucao;
        }
        public Locacao()
        {
        }
    }
}