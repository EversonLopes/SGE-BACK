using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Database;
using SistemaGerenciadorEstudantil.Models;
using SistemaGerenciadorEstudantil.Repository.Contracts;
using System.Data.Entity;

namespace SistemaGerenciadorEstudantil.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private SGEContext db = new SGEContext();



        // DELETE: api/Professors/5

        public Professor DeleteProfessor(int id)
        {
            try
            {
                var professor = GetProfessor(id);

                if (professor == null)
                {
                    throw new Exception("Professor não encontrado");
                }

                db.Professores.Remove(professor);
                db.SaveChanges();

                return professor;

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

        // GET: api/Admnistradors
        public Professor GetProfessor(int id)
        {
            try
            {
                return db.Professores.Where(c => c.ProfessorId == id).FirstOrDefault();
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Professor> GetProfessores()
        {

            try
            {
                return db.Professores.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Professor PostProfessor(Professor professor)
        {
            try
            {
                db.Professores.Add(professor);
                db.SaveChanges();
                return professor;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public Professor PutProfessor(Professor professor)
        {
            try
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return professor;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}