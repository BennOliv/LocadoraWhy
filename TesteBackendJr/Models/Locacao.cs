using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackEndJr.Models
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
        public decimal ValorLocacao { get; set; }
        public decimal ValorMultaAplicada { get; private set; }
        public decimal ValorTotal { get; private set; }

        public void GeraTotal(double ?multa) {
            decimal _multa;
            if (multa.HasValue)
            {
                 _multa = (decimal) multa.Value;
            }
            else 
            {
                _multa = 0;
            }
            ValorMultaAplicada = _multa;
            ValorTotal = ValorLocacao + ValorMultaAplicada;
        }
    }
}