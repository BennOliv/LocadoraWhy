using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.Entities;

namespace TesteBackendJr.Models.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public bool Ativo { get; set; }

        public ClienteDTO(string nome, long cPF, bool ativo)
        {
            Nome = nome;
            CPF = cPF;
            Ativo = ativo;
        }

        public ClienteDTO()
        {
        }

        public Cliente ToCliente() 
        {
            return new Cliente(Nome, CPF, Ativo);
        }
    }
}
