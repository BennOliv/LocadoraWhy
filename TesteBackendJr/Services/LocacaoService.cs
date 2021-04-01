using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendJr.Models.DTO;
using TesteBackendJr.Models.Entities;
using TesteBackendJr.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TesteBackendJr.Services
{
    public class LocacaoService
    {
        private readonly LocadoraContext context;
        public LocacaoService(LocadoraContext locadoraContext)
        {
            context = locadoraContext;
        }

        public List<LocacaoInfoDTO> BuscaTodos() 
        {
            var ret = new List<LocacaoInfoDTO>();
            foreach (Locacao loc in context.Locacaos.Include(x => x.Cliente).Include(x => x.Filme).ToList())
             {
                 ret.Add(new LocacaoInfoDTO(loc));
             }
             return ret;
        }
        public LocacaoInfoDTO BuscaLocacao(int id) 
        {
            return new LocacaoInfoDTO(context.Locacaos.Include(x => x.Cliente).Include(x => x.Filme)
                .FirstOrDefault(x => x.Id == id));
        }
        public LocacaoInfoDTO Loca(LocacaoDTO dto)
        {
            var loc = new Locacao(context.Clientes.Find(dto.ClienteId),
                                    context.Filmes.Find(dto.FilmeId),
                                    dto.ValorMulta);

            if (loc.Cliente == null || loc.Filme == null)// NotFound
                return null;

            if (!loc.Cliente.Ativo || !loc.Filme.Ativo)// Desativados           
                return new LocacaoInfoDTO { Id = -999999999 };
            
            if (loc.Filme.Estoque < 1)// Sem estoque
                return new LocacaoInfoDTO { Id = -999999998 };

            context.Locacaos.Add(loc);
            loc.Filme.Estoque -= 1;
            context.Entry(loc.Filme).State = EntityState.Modified;
            context.SaveChanges();
            return new LocacaoInfoDTO(loc);
        }
        public LocacaoInfoDTO Edita(LocacaoDTO dto)
        {
            var locacao = context.Locacaos.Include(x => x.Cliente).Include(x => x.Filme).First(x => x.Id == dto.Id);
            if (dto.ClienteId != locacao.Cliente.Id) 
            {
                var cli = context.Clientes.Find(dto.ClienteId);
                if (cli == null)
                    return null;//NotFound

                if (cli.Ativo)
                {
                    locacao.Cliente = cli;
                    context.Entry(locacao).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                    return new LocacaoInfoDTO { Id = -999999999 };//Desativado
            }
            if (dto.FilmeId != locacao.Filme.Id)
            {
                var fil = context.Filmes.Find(dto.FilmeId);

                if (fil == null)
                    return null;//NotFound
                if (!fil.Ativo)
                    return new LocacaoInfoDTO { Id = -999999999 };//Desativado

                if (fil.Estoque < 1)
                    return new LocacaoInfoDTO { Id = -999999998 };//Fora de estoue

                fil.Estoque -= 1;
                locacao.Filme.Estoque += 1;

                context.Entry(locacao.Filme).State = EntityState.Modified;

                locacao.Filme = fil;
                locacao.ValorLocacao = fil.PrecoLocacao;

                context.Entry(fil).State = EntityState.Modified;
                context.Entry(locacao).State = EntityState.Modified;
                context.SaveChanges();
            }

            return new LocacaoInfoDTO(locacao);
        }
        public NotaDTO DevolveFilme(int id)
        {
            var locacao = context.Locacaos.
                            Include(x => x.Cliente).Include(x => x.Filme).
                            First(x => x.Id == id);
            locacao.GeraTotal();
            locacao.Filme.Estoque += 1;
            context.Entry(locacao.Filme).State = EntityState.Modified;
            context.Entry(locacao).State = EntityState.Modified;
            return new NotaDTO(locacao);
        }
        public NotaDTO DevolverFilmeAtrasado(int id)
        {
            var locacao = context.Locacaos.
                            Include(x => x.Cliente).Include(x => x.Filme).
                            First(x => x.Id == id);
            locacao.GeraTotal(locacao.DataLimiteDevolucao.AddDays(5));

            locacao.Filme.Estoque += 1;
            context.Entry(locacao.Filme).State = EntityState.Modified;
            context.Entry(locacao).State = EntityState.Modified;
            return new NotaDTO(locacao);
        }
    }
}
