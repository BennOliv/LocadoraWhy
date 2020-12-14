using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.Entities;

namespace TesteBackendJr.Models.DTO
{
    public class LocacaoDTO
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long FilmeId { get; set; }
        public double ValorMulta { get; set; }

        public LocacaoDTO(long idCliente, long idFilme, double valorMulta)
        {
            ClienteId = idCliente;
            FilmeId = idFilme;
            ValorMulta = valorMulta;
        }
        public LocacaoDTO()
        {
        }
    }
}