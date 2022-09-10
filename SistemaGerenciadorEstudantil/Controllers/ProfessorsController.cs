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
    public class ProfessorsController : ApiController
    {
        ProfessorRepository professorRepository = new ProfessorRepository();

        // GET: api/Professores
        [HttpGet]
        public IEnumerable<Professor> GetProfessors()
        {
            try
            {
                var lista = professorRepository.GetProfessores();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Professores/5
        [ResponseType(typeof(Professor))]
        public IHttpActionResult GetProfessor(int id)
        {
            Professor professor = professorRepository.GetProfessor(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        // PUT: api/Professores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfessor(int id, Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.ProfessorId)
            {
                return BadRequest();
            }

            try
            {
                professorRepository.PutProfessor(professor);
                return Ok(professor);
            }
            catch (Exception e)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Professores
        [ResponseType(typeof(Professor))]
        public IHttpActionResult PostProfessor(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            professorRepository.PostProfessor(professor);

            return CreatedAtRoute("DefaultApi", new { id = professor.ProfessorId }, professor);
        }

        // DELETE: api/Professores/5
        [ResponseType(typeof(Professor))]
        public IHttpActionResult DeleteProfessor(int id)
        {
            Professor professor = professorRepository.GetProfessor(id);
            if (professor == null)
            {
                return NotFound();
            }

            professorRepository.DeleteProfessor(professor.ProfessorId);

            return Ok(professor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                professorRepository.GetDb().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}