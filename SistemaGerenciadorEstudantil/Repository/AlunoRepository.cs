using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SistemaGerenciadorEstudantil.Models;
using SistemaGerenciadorEstudantil.Repository.Contracts;
using SistemaGerenciadorEstudantil.Database;
using System.Web.Http;

namespace SistemaGerenciadorEstudantil.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private SGEContext db = new SGEContext();

        // DELETE: api/Alunoes/5

        public Aluno DeleteAluno(int id)
        {
            try
            {
                var aluno = GetAluno(id);

                if (aluno == null)
                {
                    throw new Exception("Candidato não encontrado");
                }

                db.Alunos.Remove(aluno);
                db.SaveChanges();

                return aluno;

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        // GET: api/Alunoes
        public Aluno GetAluno(int id)
        {
            try
            {
                return db.Alunos.Include(c => c.Curso).Include(c => c.DisciplinasAlunos).Where(c => c.AlunoId == id).FirstOrDefault();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Aluno> GetAlunos()
        {

            try
            {

                return db.Alunos.Include(c => c.Curso).Include(c => c.DisciplinasAlunos).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Aluno PostAluno(Aluno aluno)
        {
            try
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return aluno;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public Aluno PutAluno(Aluno aluno)
        {
            try
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                DeleteDisciplinasAluno(aluno);
                // PostDeleteDisciplinasAluno(aluno);
                return aluno;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteDisciplinasAluno(Aluno aluno)
        {
            try
            {
                var disciplinaAluno = (aluno.AlunoId);
                if (disciplinaAluno != null)
                    foreach (var item in aluno.DisciplinasAlunos)
                    {
                        db.DisciplinasAlunos.Remove(item);
                    }
                db.SaveChanges();
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


        public void PostDisciplinasAluno(Aluno aluno)
        {
            foreach (var item in aluno.DisciplinasAlunos.ToList())
            {

                try
                {
                    var discplinaAluno = new DisciplinasAlunos();
                    discplinaAluno.Id = item.Id;
                    discplinaAluno.DisciplinaID_FK = item.DisciplinaID_FK;
                    db.DisciplinasAlunos.Add(discplinaAluno);

                    db.SaveChanges();
                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


            }

        }
        public List<DisciplinasAlunos> GetDisciplinaAluno(int AlunoId)
        {
            try
            {
                return db.DisciplinasAlunos.Where(t => t.AlunoID_FK == AlunoId).ToList();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
    }
}






