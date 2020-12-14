using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBackendJr.Models;
using TesteBackendJr.Models.DTO;
using TesteBackendJr.Models.Entities;
using TesteBackendJr.Repositories;
using TesteBackendJr.Services;

namespace TesteBackendJr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly LocadoraContext _context;

        public ClientesController(ClienteService clienteService, LocadoraContext context)
        {
            _clienteService = clienteService;
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return _clienteService.FindAll();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(long id)
        {
            var cliente = _clienteService.BuscaCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<Cliente> PutCliente(long id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("Ids não correspondentes.");
            }

            try
            {
                var ret = _clienteService.Edit(id, cliente);
                if (ret == null)
                {
                    return BadRequest("CPF já cadastrado.");
                }
                return Ok(ret);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_clienteService.BuscaCliente(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Cliente> PostCliente(ClienteDTO cliente)
        {

            cliente.Id = _clienteService.Cadastra(cliente);
            if(cliente.Id == 0)
                return BadRequest("CPF já cadastrado.");

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCliente(long id)
        {
            var ret = _clienteService.Desativa(id);

            if (ret == false)
                return NotFound();
            else
                return NoContent();
        }
    }
}
