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
    public class CursoesController : ApiController
    {
        CursoRepository cursoRepository = new CursoRepository();

        // GET: api/Cursos
        public IHttpActionResult GetCursos()
        {
            try
            {
                var lista = cursoRepository.GetCursos();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Cursos/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult GetCursos(int id)
        {
            Curso cursos = cursoRepository.GetCurso(id);
            var cursosDisciplinas = cursoRepository.GetDisciplinasCurso(id);
            cursos.DisciplinasCursos = new List<DisciplinasCursos>();

            foreach (var item in cursosDisciplinas) {
                cursos.DisciplinasCursos.Add(item);
            }

            if (cursos == null)
            {
                return NotFound();
            }

            return Ok(cursos);
        }

        // PUT: api/Cursos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCursos(int id, Curso cursos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursos.CursoId)
            {
                return BadRequest();
            }

            try
            {
                cursoRepository.PutCurso(cursos);
                return Ok(cursos);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        // POST: api/Cursos
        [ResponseType(typeof(Curso))]
        public IHttpActionResult PostCursos(Curso cursos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cursoRepository.PostCurso(cursos);


            return CreatedAtRoute("DefaultApi", new { id = cursos.CursoId }, cursos);
        }

        // DELETE: api/Cursos/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult DeleteCursos(int id)
        {
            Curso cursos = cursoRepository.GetCurso(id);
            if (cursos == null)
            {
                return NotFound();
            }

            cursoRepository.DeleteCurso(cursos.CursoId);

            return Ok(cursos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cursoRepository.GetDb();
            }
            base.Dispose(disposing);
        }

    }
}