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
    public class ClienteService
    {
        private readonly LocadoraContext Context;

        public ClienteService(LocadoraContext context)
        {
            Context = context;
        }

        public Cliente BuscaCliente(long id) {
            var ret = Context.Clientes.FirstOrDefault(x => x.Id == id);
            if (!ret.Nome.Equals(null))
            {
                return ret;
            }
            return null;
        }
        public List<Cliente> FindAll() 
        {
            return Context.Clientes.ToList();
        }

        public long Cadastra(ClienteDTO cliente)
        {
            var cli = cliente.ToCliente();

            if (Context.Clientes.Any(cli => cli.CPF == cliente.CPF))
                return 0;

            Context.Clientes.Add(cli);
            Context.SaveChanges();
            return cli.Id;
        }

        public Cliente Edit(long id, Cliente cliente)
        {
            if (Context.Clientes.Any(cli => cli.CPF == cliente.CPF && cli.Id != id))
            {
                return null;
            }

            Context.Entry(cliente).State = EntityState.Modified;
            Context.SaveChanges();
            
            return Context.Clientes.Find(id);
        }
        public bool Desativa(long id) 
        {
            var cliente = Context.Clientes.Find(id);
            if (cliente == null)
            {
                return false;
            }
            
            cliente.Ativo = false;

            Context.Entry(cliente).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }
    }
}
