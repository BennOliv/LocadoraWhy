using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.Entities;

namespace TesteBackendJr.Models.DTO
{
    public class LocacaoInfoDTO
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long FilmeId { get; set; }
        public string DataLocacao { get; set; }
        public string DataLimiteDevolucao { get; set; }
        public double ValorMulta { get; set; }

        public LocacaoInfoDTO() { }
        public LocacaoInfoDTO(Locacao locacao) 
        {
            Id = locacao.Id;
            ClienteId = locacao.Cliente.Id;
            FilmeId = locacao.Filme.Id;
            DataLocacao = locacao.DataLocacao.ToString("MM/dd/yyyy");
            DataLimiteDevolucao = locacao.DataLimiteDevolucao.ToString("MM/dd/yyyy");
            ValorMulta = locacao.ValorMulta;
        }
    }
}
