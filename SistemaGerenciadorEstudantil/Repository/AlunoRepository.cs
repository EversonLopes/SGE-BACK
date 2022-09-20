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
                PostDisciplinasAluno(aluno);


                    /*
                    var disciplinasAlunos = new DisciplinasAlunos();                    

                    disciplinasAlunos.AlunoID_FK = aluno.AlunoId;
                    disciplinasAlunos.DisciplinaID_FK = aluno.DisciplinasAlunos.FirstOrDefault().DisciplinaID_FK;
                    disciplinasAlunos.Nota1 = aluno.DisciplinasAlunos.FirstOrDefault().Nota1;
                    disciplinasAlunos.Nota2 = aluno.DisciplinasAlunos.FirstOrDefault().Nota2;
                    disciplinasAlunos.MediaFinal = aluno.DisciplinasAlunos.FirstOrDefault().MediaFinal;

                    DeleteDisciplinasAluno(aluno);


                    aluno.DisciplinasAlunos.Add(disciplinasAlunos);
                    db.DisciplinasAlunos.Add(disciplinasAlunos);
                    db.SaveChanges();
                */
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

                var disciplinaAluno = GetDisciplinaAluno(aluno.AlunoId);
                var discplinaAlunoTemp = aluno.DisciplinasAlunos;


                if (disciplinaAluno != null)
                { 
                    
                    foreach (var item in disciplinaAluno)
                    {
                        if(aluno.DisciplinasAlunos.LastOrDefault().DisciplinaID_FK==item.DisciplinaID_FK)
                            
                          { db.DisciplinasAlunos.Remove(item); }
                     
                        db.SaveChanges();
                    }
                    
                    
              
                }

     
            }
            
            catch (Exception e) { 
                throw new Exception(e.Message);
            }
        }
        public DbContext GetDb()
        {
            return db;
        }


        public void PostDisciplinasAluno(Aluno aluno)
        {
        

                try
                {
                var discplinaAluno = new DisciplinasAlunos();
                discplinaAluno.AlunoID_FK = aluno.AlunoId; ;
                discplinaAluno.DisciplinaID_FK = aluno.DisciplinasAlunos.LastOrDefault(). DisciplinaID_FK;
                discplinaAluno.Nota1 = aluno.DisciplinasAlunos.LastOrDefault().Nota1;
                discplinaAluno.Nota2 = aluno.DisciplinasAlunos.LastOrDefault().Nota2;
                discplinaAluno.MediaFinal = aluno.DisciplinasAlunos.LastOrDefault().MediaFinal;
                db.DisciplinasAlunos.Add(discplinaAluno);

                    db.SaveChanges();
                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
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






