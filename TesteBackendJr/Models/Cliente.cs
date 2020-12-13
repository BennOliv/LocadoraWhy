using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBackEndJr.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public bool State { get; set; }
    }
}
