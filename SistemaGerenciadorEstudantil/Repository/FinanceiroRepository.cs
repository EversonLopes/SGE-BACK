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
    public class FinanceiroRepository : IFinanceiroRepository
    {
        private SGEContext db = new SGEContext();



        // DELETE: api/Financeiros/5

        public Financeiro DeleteFinanceiro(int id)
        {
            try
            {
                var financeiro = GetFinanceiro(id);

                if (financeiro == null)
                {
                    throw new Exception("Financeiro não encontrado");
                }

                db.Financeiros.Remove(financeiro);
                db.SaveChanges();

                return financeiro;

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        // GET: api/Admnistradors
        public Financeiro GetFinanceiro(int id)
        {
            try
            {
                return db.Financeiros.Where(c => c.FinanceiroId == id).FirstOrDefault();
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

        public List<Financeiro> GetFinanceiros()
        {

            try
            {
                return db.Financeiros.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Financeiro PostFinanceiro(Financeiro financeiro)
        {
            try
            {
                db.Financeiros.Add(financeiro);
                db.SaveChanges();
                return financeiro;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public Financeiro PutFinanceiro(Financeiro financeiro)
        {
            try
            {
                db.Entry(financeiro).State = EntityState.Modified;
                db.SaveChanges();
                return financeiro;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




    }
}





