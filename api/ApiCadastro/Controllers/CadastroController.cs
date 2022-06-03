using ApiCadastro.Data;
using ApiCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {

        [HttpPost("cadastrar")]

        public IActionResult Cadastrar([FromBody] Cadastro cadastroReq)
        {
            using (var contexto = new CadastroContext())
            {
                var cadastro = new Cadastro()
                {
                    Nome = cadastroReq.Nome,
                    Sobrenome = cadastroReq.Sobrenome,
                    Email = cadastroReq.Email,
                    Data = cadastroReq.Data,
                    Endereco = cadastroReq.Endereco,
                    CEP = cadastroReq.CEP,
                    Telefone = cadastroReq.Telefone,
                    Sexo = cadastroReq.Sexo,
                    Ensino = cadastroReq.Ensino,
                    Curso = cadastroReq.Curso

                };

                contexto.Cadastros.Add(cadastro);
                contexto.SaveChanges();
                return CreatedAtAction(nameof(ListarPorId), new { Id = cadastro.Id }, cadastro);
            }
        }

        [HttpGet("listarPorId/{id}")]
        public IActionResult ListarPorId(int id)
        {
            using (var contexto = new CadastroContext())
            {
                var cadastro = contexto.Cadastros.Where(c => c.Id == id).FirstOrDefault();
                if (cadastro == null)
                {
                    return NotFound();
                }

                return Ok(cadastro);
            }
        }

        [HttpGet("listarCadastros")]
        public IActionResult Listar()
        {
            using (var contexto = new CadastroContext())
            {
                var cadastros = contexto.Cadastros.ToList();
                if (cadastros == null)
                {
                    return NotFound();
                }

                return Ok(cadastros);
            }
        }

        [HttpDelete("deletarCadastro/{id}")]

        public IActionResult Deletar(int id)
        {
            using (var contexto = new CadastroContext())
            {
                var cadastro = contexto.Cadastros.Where(c => c.Id == id).FirstOrDefault();
                if (cadastro == null)
                {
                    return NotFound();
                }

                contexto.Cadastros.Remove(cadastro);
                contexto.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut("AtualizarCadastro/{id}")]

        public IActionResult Atualizar(int id, [FromBody] Cadastro cadastroCorpo)
        {
            using (var contexto = new CadastroContext())
            {
                var cadastro = contexto.Cadastros.Where(c => c.Id == id).FirstOrDefault();
                if (cadastro == null)
                {
                    return NotFound();
                }

                cadastro.Nome = cadastroCorpo.Nome;
                cadastro.Sobrenome = cadastroCorpo.Sobrenome;
                cadastro.Email = cadastroCorpo.Email;
                //cadastro.Data = cadastroCorpo.Data;
                cadastro.Endereco = cadastroCorpo.Endereco;
                cadastro.CEP = cadastroCorpo.CEP;
                cadastro.Telefone = cadastroCorpo.Telefone;
                cadastro.Sexo = cadastroCorpo.Sexo;
                cadastro.Ensino = cadastroCorpo.Ensino;
                cadastro.Curso = cadastroCorpo.Curso;

                contexto.SaveChanges();
                return NoContent();
            }
        }



    }
}
