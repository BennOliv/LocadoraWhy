using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.Entities;

namespace TesteBackendJr.Models.DTO
{
    public class NotaDTO
    {
        public long LocacaoId { get; set; }
        public long ClienteId { get; set; }
        public long FilmeId { get; set; }
        public double ValorLocacao { get; set; }
        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
        public double ValorMultaAplicada { get; set; }
        public double ValorTotal { get; set; }
        public string Observacao { get; set; }

        public NotaDTO() { }
        public NotaDTO(Locacao locacao) {
            LocacaoId = locacao.Id;
            ClienteId = locacao.Cliente.Id;
            FilmeId = locacao.Filme.Id;
            ValorLocacao = locacao.ValorLocacao;
            DataLocacao = locacao.DataLocacao.ToString("MM/dd/yyyy");
            DataDevolucao = locacao.DataDevolucao.ToString("MM/dd/yyyy");
            ValorMultaAplicada = ( locacao.ValorTotal == ValorLocacao ? 0 : locacao.ValorMulta);
            ValorTotal = locacao.ValorTotal;
            observacao = (ValorMultaAplicada == 0 ? "Devolução dentro do prazo. Sem multa por atraso."
                                                    : "Devolução com atraso. Será cobrado R$"+ValorMultaAplicada+" de multa.");
        }
    }
}
