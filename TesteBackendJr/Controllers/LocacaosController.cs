using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBackendJr.Models.DTO;
using TesteBackendJr.Models.Entities;
using TesteBackendJr.Repositories;
using TesteBackendJr.Services;

namespace TesteBackendJr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private readonly LocacaoService locacaoService;

        public LocacaosController(LocacaoService service)
        {
            locacaoService = service;
        }

        // GET: api/Locacaos
        [HttpGet]
        public ActionResult<IEnumerable<LocacaoInfoDTO>> GetLocacaos()
        {
            return locacaoService.BuscaTodos();
        }

        // GET: api/Locacaos/{id}
        [HttpGet("{id}")]
        public ActionResult<LocacaoInfoDTO> GetLocacao(int id)
        {
            var locacao = locacaoService.BuscaLocacao(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }
        // POST: api/Locacaos
        [HttpPost]
        public ActionResult<LocacaoInfoDTO> PostLocacao(LocacaoDTO locacao)
        {
            var ret = locacaoService.Loca(locacao);

            if (ret == null)
                return NotFound();
            if (ret.Id == -999999999)
                return BadRequest("Cliente ou Filme Desativados.");
            if (ret.Id == -999999998)
                return BadRequest("Filme fora de estoque.");

            return Created("GetLocacao", ret);
        }
        // PUT: api/Locacaos/{id}
        [HttpPut("{id}")]
        public ActionResult<LocacaoInfoDTO> PutLocacao(int id, LocacaoDTO locacao)
        {
            if (id != locacao.Id)
            {
                return BadRequest("Ids não correspondentes.");
            }

            var ret = locacaoService.Edita(locacao);

            if (ret == null)
                return NotFound();
            if (ret.Id == -999999999)
                return BadRequest("Cliente ou Filme Desativados.");
            if (ret.Id == -999999998)
                return BadRequest("Filme fora de estoque.");


            return NoContent();
        }

        //GET: api/Locacaos/devolver/{id}
        [HttpGet("devolver/{id}")]
        public ActionResult<NotaDTO> DevolveLocacao(int id)
        {
            return locacaoService.DevolveFilme(id);
        }

        //GET: api/Locacaos/devolverAtrasado/{id}
        [HttpGet("devolverAtrasado/{id}")]
        public ActionResult<NotaDTO> DevolveLocacaoAtrasado(int id)
        {
            return locacaoService.DevolverFilmeAtrasado(id);
        }
    }
}
