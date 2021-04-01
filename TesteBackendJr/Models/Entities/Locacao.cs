using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackendJr.Models.Entities
{
    public class Locacao
    {
        public int Id { get; set; }
        [Display(Name ="ClienteId")]
        public Cliente Cliente { get; set; }
        [Display(Name = "FilmeId")]
        public Filme Filme { get; set; }
        //Eu faria mais uma tabela para que pudessem ser locados. Mas como no desafio citava, especificamente, "Clientes, Filmes e Locacao" achei melhor só fazer o que foi pedido.
        //public ICollection<Filme> Filmes { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataLimiteDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double ValorLocacao { get; set; }
        public double ValorMulta { get; set; }
        public double ValorTotal { get; private set; }

        //Método exclusivo para fazer testes de atraso na entrega
        public void GeraTotal(DateTime data) {
            if (data.CompareTo(DataLimiteDevolucao) <= 0)
            {
                ValorTotal = ValorLocacao;
                return;
            }
            ValorTotal = ValorLocacao + ValorMulta;
        }

        public void GeraTotal() 
        {
            if (DateTime.Now.CompareTo(DataLimiteDevolucao) <=0)
            {
                ValorTotal = ValorLocacao;
                return;
            }
            ValorTotal = ValorLocacao + ValorMulta;
        }
        public Locacao(int id,Cliente cliente, Filme filme, double vlMulta)
        {
            Id = id;
            Cliente = cliente;
            Filme = filme;
            ValorLocacao = filme.PrecoLocacao;
            ValorMulta = vlMulta;
            DataLocacao = DateTime.Now;
            DataLimiteDevolucao = DateTime.Now.AddDays(7);
        }
        public Locacao(Cliente cliente, Filme filme, double vlMulta)
        {
            Cliente = cliente;
            Filme = filme;
            ValorLocacao = filme.PrecoLocacao;
            ValorMulta = vlMulta;
            DataLocacao = DateTime.Now;
            DataLimiteDevolucao = DateTime.Now.AddDays(7);
        }
        public Locacao()
        {
        }
    }
}