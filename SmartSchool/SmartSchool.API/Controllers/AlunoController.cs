using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Fernando Augusto",
                Sobrenome = "da Silva Gallardo",
                Telefone = "123454356"
            },
            new Aluno(){
                Id = 2,
                Nome = "Alana Augusto",
                Sobrenome = "Silva Silva",
                Telefone = "345345345"
            },
            new Aluno(){
                Id = 3,
                Nome = "Morgana Augusto",
                Sobrenome = "ldKSO DOAKS",
                Telefone = "56756756"
            },
        };

        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET: api/Aluno/byid/3
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado");
            else
                return Ok(aluno);
        }

        // GET: api/Aluno/byname?nome=Fernando&sobrenome=Augusto
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
                a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado");
            else
                return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }


        // api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        // api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
