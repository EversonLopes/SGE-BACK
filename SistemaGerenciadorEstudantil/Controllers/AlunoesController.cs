using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaGerenciadorEstudantil.Database;
using SistemaGerenciadorEstudantil.Models;
using SistemaGerenciadorEstudantil.Repository;

namespace SistemaGerenciadorEstudantil.Controllers
{
    public class AlunoesController : ApiController
    {
        AlunoRepository alunoRepository = new AlunoRepository();

        // GET: api/Alunoes
        [HttpGet]
        public IEnumerable<Aluno> GetAlunos()
        {
            try
            {
                var lista = alunoRepository.GetAlunos();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = alunoRepository.GetAluno(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        // PUT: api/Alunoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            try
            {
                alunoRepository.PutAluno(aluno);
                return Ok(aluno);
            }
            catch (Exception e)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Alunoes
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            alunoRepository.PostAluno(aluno);

            return CreatedAtRoute("DefaultApi", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult DeleteAluno(int id)
        {
            Aluno aluno = alunoRepository.GetAluno(id);
            if (aluno == null)
            {
                return NotFound();
            }

            alunoRepository.DeleteAluno(aluno.AlunoId);

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                alunoRepository.GetDb().Dispose();
            }
            base.Dispose(disposing);
        }

    }
}