using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models;
using TesteBackendJr.Repositories;

namespace TesteBackendJr.Services
{
    public class SeedingService
    {
        private readonly LocadoraContext _context;
        public SeedingService(LocadoraContext context)
        {
            _context = context;
        }

        public void Seed() 
        {
            if (_context.Clientes.Any() || _context.Filmes.Any() || _context.Locacaos.Any())
            {
                return;
            }

            var cli = new Cliente("Jorge Silva", 11111111100, true);
            var fil = new Filme("Corrida contra o tempo", 1, 21.5, true);
            var loc = new Locacao(cli, fil, fil.PrecoLocacao, 10.75, DateTime.Now, DateTime.Now.AddDays(7));

            _context.Clientes.Add(cli);
            _context.Filmes.Add(fil);
            _context.Locacaos.Add(loc);

            _context.SaveChanges();
        }

    }
}
