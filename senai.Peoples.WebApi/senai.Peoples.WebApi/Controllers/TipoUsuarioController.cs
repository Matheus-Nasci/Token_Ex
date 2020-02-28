using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using senai.Peoples.WebApi.Repositories;

namespace senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    //[Authorize]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {   
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IEnumerable<TipoUsuarioDomain> Get()
        {
            return _TipoUsuarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                return Ok(tipoUsuarioBuscado);
            }

            return NotFound("Nenhum Tipo de Usuario encontrado com esse ID");
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoTipo)
        {
            if (novoTipo.NomeUsuario == null)
            {
                return BadRequest("O nome do Tipo do Usuario é obrigatório!");
            }
            _TipoUsuarioRepository.Cadastrar(novoTipo);

            return Created("http://localhost:5000/api/Funcionarios", novoTipo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuarioDomain TipoBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if (TipoBuscado != null)
            {
                _TipoUsuarioRepository.Deletar(id);

                return Ok($"O Tipo de Usuário {id} foi deletado com sucesso!");
            }

            return NotFound($"Nenhum Tipo de Usuário encontrado com esse ID - {id}");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoAtualizado)
        {
            TipoUsuarioDomain TipoUsuarioAtualizado = _TipoUsuarioRepository.BuscarPorId(id);

            if (TipoUsuarioAtualizado != null)
            {
                try
                {
                    _TipoUsuarioRepository.Atualizar(id, tipoAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Tipo Usuário não encontrado",
                        erro = true
                    }
                );
        }
    }
}