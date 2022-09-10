using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;
using SistemaGerenciadorEstudantil.Database;
using SistemaGerenciadorEstudantil.Repository.Contracts;
using System.Data.Entity;

namespace SistemaGerenciadorEstudantil.Repository
{
    public class CursoRepository:ICursoRepository
    {
        private SGEContext db = new SGEContext();



        // DELETE: api/Cursos/5

        public Curso DeleteCurso(int id)
        {
            try
            {
                var curso = GetCurso(id);

                if (curso == null)
                {
                    throw new Exception("Curso não encontrado");
                }

                db.Cursos.Remove(curso);
                db.SaveChanges();

                return curso;

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        // GET: api/Admnistradors
        public Curso GetCurso(int id)
        {
            try
            {
                var temp = db.Cursos.Include(c => c.DisciplinasCursos).Where(c => c.CursoId == id).FirstOrDefault();
                return temp;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Curso> GetCursos()
        {

            try
            {
                return db.Cursos.Include(c=>c.DisciplinasCursos).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Curso PostCurso(Curso curso)
        {
            try
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return curso;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public DbContext GetDb()
        {
            return db;
        }

        public Curso PutCurso(Curso curso)
        {
            try
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();

                if (curso.DisciplinasCursos != null)
                { 
                var disciplinasCursos = new DisciplinasCursos();

                disciplinasCursos.CursoID_FK = curso.CursoId;
                disciplinasCursos.DisciplinaID_FK = curso.DisciplinasCursos.FirstOrDefault().DisciplinaID_FK;

                curso.DisciplinasCursos.Add(disciplinasCursos);
                db.DisciplinasCursos.Add(disciplinasCursos);
                db.SaveChanges();
            }
                return curso;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<DisciplinasCursos> GetDisciplinasCurso(int CursoId)
        {
            try
            {
                return db.DisciplinasCursos.Include(vt => vt.Disciplina).Include(vt => vt.Curso).Where(t => t.CursoID_FK == CursoId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void DeleteDisciplinasCurso(Curso curso)
        {
            try
            {
                var disciplinaCurso = GetDisciplinasCurso(curso.CursoId);

                if (disciplinaCurso != null)
                {
                    foreach (var item in disciplinaCurso)
                    {
                        db.DisciplinasCursos.Remove(item);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PostDisciplinasCurso(Curso curso)
        {
            try
            {


                var disciplinasCursos = new DisciplinasCursos();

                disciplinasCursos.CursoID_FK = curso.CursoId;
                disciplinasCursos.DisciplinaID_FK = curso.DisciplinasCursos.FirstOrDefault().DisciplinaID_FK;

                db.DisciplinasCursos.Add(disciplinasCursos);               
                db.SaveChanges();

                //DeleteDisciplinasCurso(curso);
                //PostDisciplinasCurso(curso);


               // db.DisciplinasCursos.Add(disciplinaCurso);
                 //   db.SaveChanges();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}