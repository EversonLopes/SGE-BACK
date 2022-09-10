using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Repository.Contracts;
using SistemaGerenciadorEstudantil.Models;
using SistemaGerenciadorEstudantil.Database;
using System.Data.Entity;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
 
        public class DisciplinaRepository : IDisciplinaRepository
        {
            private SGEContext db = new SGEContext();



            // DELETE: api/Disciplinas/5

            public Disciplina DeleteDisciplina(int id)
            {
                try
                {
                    var disciplina = GetDisciplina(id);

                    if (disciplina == null)
                    {
                        throw new Exception("Disciplina não encontrado");
                    }

                    db.Disciplinas.Remove(disciplina);
                    db.SaveChanges();

                    return disciplina;

                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }


            // GET: api/Admnistradors
            public Disciplina GetDisciplina(int id)
            {
                try
                {
                    return db.Disciplinas.Where(c => c.DisciplinaId == id).FirstOrDefault();
                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            public List<Disciplina> GetDisciplinas()
            {

                try
                {
                    return db.Disciplinas.ToList();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            public Disciplina PostDisciplina(Disciplina disciplina)
            {
                try
                {
                    db.Disciplinas.Add(disciplina);
                    db.SaveChanges();
                    return disciplina;
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

        public Disciplina PutDisciplina(Disciplina disciplina)
            {
                try
                {
                    db.Entry(disciplina).State = EntityState.Modified;
                    db.SaveChanges();
                    return disciplina;
                }

                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
}