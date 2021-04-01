using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.Entities;
using TesteBackendJr.Repositories;
using Microsoft.EntityFrameworkCore;
using TesteBackendJr.Models.DTO;

namespace TesteBackendJr.Services
{
    public class FilmeService
    {
        private readonly LocadoraContext Context;
        public FilmeService(LocadoraContext context)
        {
            Context = context;
        }

        public Filme BuscaFilme(int id) {
            var ret = Context.Filmes.FirstOrDefault(x => x.Id == id);
            if (!ret.Nome.Equals(null))
            {
                return ret;
            }
            return null;
        }
        public List<Filme> FindAll() 
        {
            return Context.Filmes.ToList();
        }

        public int Cadastra(Filme filme)
        {
            var fil = filme;

            if (Context.Filmes.Any(x => x.Nome.Equals(filme.Nome)))
                return 0;

            Context.Filmes.Add(fil);
            Context.SaveChanges();
            return fil.Id;
        }

        public Filme Edit(int id, Filme filme)
        {
            if (Context.Filmes.Any(cli => cli.Nome.Equals(filme.Nome) && cli.Id != id))
            {
                return null;
            }

            Context.Entry(filme).State = EntityState.Modified;
            Context.SaveChanges();
            
            return Context.Filmes.Find(id);
        }
        public bool Desativa(int id) 
        {
            var filme = Context.Filmes.Find(id);
            if (filme == null)
            {
                return false;
            }

            filme.Ativo = false;

            Context.Entry(filme).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }
    }
}
