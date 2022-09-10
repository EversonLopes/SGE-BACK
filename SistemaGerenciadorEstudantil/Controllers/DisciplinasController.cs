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
using SistemaGerenciadorEstudantil.Repository.Contracts;

namespace SistemaGerenciadorEstudantil.Controllers
{
    public class DisciplinasController : ApiController
    {
        DisciplinaRepository disciplinaRepository = new DisciplinaRepository();

        // GET: api/Disciplinas
        public IHttpActionResult GetDisciplinas()
        {
             try
            {
                var lista = disciplinaRepository.GetDisciplinas();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult GetDisciplinas(int id)
        {
            Disciplina disciplinas = disciplinaRepository.GetDisciplina(id);
            if (disciplinas == null)
            {
                return NotFound();
            }

            return Ok(disciplinas);
        }

        // PUT: api/Disciplinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisciplinas(int id, Disciplina disciplinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplinas.DisciplinaId)
            {
                return BadRequest();
            }

            try
            {
                disciplinaRepository.PutDisciplina(disciplinas);
                return Ok(disciplinas);
            }
            catch (Exception e)
            {
                return null;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Disciplinas
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult PostDisciplinas(Disciplina disciplinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            disciplinaRepository.PostDisciplina(disciplinas);
           

            return CreatedAtRoute("DefaultApi", new { id = disciplinas.DisciplinaId }, disciplinas);
        }

        // DELETE: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult DeleteDisciplinas(int id)
        {
            Disciplina disciplinas = disciplinaRepository.GetDisciplina(id);
            if (disciplinas == null)
            {
                return NotFound();
            }

            disciplinaRepository.DeleteDisciplina(disciplinas.DisciplinaId);           

            return Ok(disciplinas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              disciplinaRepository.GetDb();
            }
            base.Dispose(disposing);
        }

     
    }
}