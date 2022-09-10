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
    public class FinanceiroesController : ApiController
    {

        FinanceiroRepository financeiroRepository = new FinanceiroRepository();
        // GET: api/Financeiroes

        [HttpGet]
        public IEnumerable<Financeiro> GetFinanceiros()
        {
            try
            {
                var lista = financeiroRepository.GetFinanceiros();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Financeiroes/5
        [ResponseType(typeof(Financeiro))]
        public IHttpActionResult GetFinanceiro(int id)
        {
            Financeiro financeiro = financeiroRepository.GetFinanceiro(id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return Ok(financeiro);
        }

        // PUT: api/Financeiroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinanceiro(int id, Financeiro financeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != financeiro.FinanceiroId)
            {
                return BadRequest();
            }

            try
            {
                financeiroRepository.PutFinanceiro(financeiro);
                return Ok(financeiro);
            }
            catch (Exception e)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/Financeiroes
        [ResponseType(typeof(Financeiro))]
        public IHttpActionResult PostFinanceiro(Financeiro financeiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            financeiroRepository.PostFinanceiro(financeiro);

            return CreatedAtRoute("DefaultApi", new { id = financeiro.FinanceiroId }, financeiro);
        }

        // DELETE: api/Financeiroes/5
        [ResponseType(typeof(Financeiro))]
        public IHttpActionResult DeleteFinanceiro(int id)
        {
            Financeiro financeiro = financeiroRepository.GetFinanceiro(id);
            if (financeiro == null)
            {
                return NotFound();
            }

            financeiroRepository.DeleteFinanceiro(financeiro.FinanceiroId);

            return Ok(financeiro);
        }
    }
}