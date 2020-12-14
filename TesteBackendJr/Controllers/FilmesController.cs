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
    public class FilmesController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmesController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        // GET: api/Filmes
        [HttpGet]
        public ActionResult<IEnumerable<Filme>> GetFilmes()
        {
            return _filmeService.FindAll();
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public ActionResult<Filme> GetFilme(long id)
        {
            var filme = _filmeService.BuscaFilme(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult<Filme> PutFilme(long id, Filme filme)
        {
            if (id != filme.Id)
            {
                return BadRequest("Ids não correspondentes.");
            }

            try
            {
                var ret = _filmeService.Edit(id, filme);
                if (ret == null)
                {
                    return BadRequest("Filme já cadastrado.");
                }
                return Ok(ret);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_filmeService.BuscaFilme(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Filmes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Filme> PostFilme(Filme filme)
        {

            filme.Id = _filmeService.Cadastra(filme);
            if(filme.Id == 0)
                return BadRequest("Filme já cadastrado.");

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteFilme(long id)
        {
            var ret = _filmeService.Desativa(id);

            if (ret == false)
                return NotFound();
            else
                return NoContent();
        }
    }
}
