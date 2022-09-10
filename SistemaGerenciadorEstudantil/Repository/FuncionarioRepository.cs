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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private SGEContext db = new SGEContext();



        // DELETE: api/Funcionarios/5

        public Funcionario DeleteFuncionario(int id)
        {
            try
            {
                var funcionario = GetFuncionario(id);

                if (funcionario == null)
                {
                    throw new Exception("Funcionario não encontrado");
                }

                db.Funcionarios.Remove(funcionario);
                db.SaveChanges();

                return funcionario;

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        // GET: api/Admnistradors
        public Funcionario GetFuncionario(int id)
        {
            try
            {
                return db.Funcionarios.Where(c => c.FuncionarioId == id).FirstOrDefault();
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

        public List<Funcionario> GetFuncionarios()
        {

            try
            {
                return db.Funcionarios.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Funcionario PostFuncionario(Funcionario funcionario)
        {
            try
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return funcionario;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public Funcionario PutFuncionario(Funcionario funcionario)
        {
            try
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return funcionario;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




    }
}





