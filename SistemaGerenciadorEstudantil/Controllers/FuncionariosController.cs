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
    public class FuncionariosController : ApiController
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();



        // GET: api/Funcionarios
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            try
            {
                var lista = funcionarioRepository.GetFuncionarios();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Funcionarios/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult GetFuncionarios(int id)
        {
            Funcionario funcionarios = funcionarioRepository.GetFuncionario(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }

        // PUT: api/Funcionarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionarios(int id, Funcionario funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionarios.FuncionarioId)
            {
                return BadRequest();
            }

            try
            {
                funcionarioRepository.PutFuncionario(funcionarios);
                return Ok(funcionarios);
            }
            catch (Exception e)
            {
                return null;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Funcionarios
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult PostFuncionarios(Funcionario funcionarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            funcionarioRepository.PostFuncionario(funcionarios);


            return CreatedAtRoute("DefaultApi", new { id = funcionarios.FuncionarioId }, funcionarios);
        }

        // DELETE: api/Funcionarios/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult DeleteFuncionarios(int id)
        {
            Funcionario funcionarios = funcionarioRepository.GetFuncionario(id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            funcionarioRepository.DeleteFuncionario(funcionarios.FuncionarioId);

            return Ok(funcionarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                funcionarioRepository.GetDb();
            }
            base.Dispose(disposing);
        }
    }
}