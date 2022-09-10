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
    public class AdministradorsController : ApiController
    {
        AdminstradorRepository administradorRepository = new AdminstradorRepository();
        
        

        // GET: api/Administradors
        public IEnumerable<Administrador> GetAdministradors()
        {
            try
            {
                var lista = administradorRepository.GetAdministradores();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult GetAdministradors(int id)
        {
            Administrador administradors = administradorRepository.GetAdministrador(id);
            if (administradors == null)
            {
                return NotFound();
            }

            return Ok(administradors);
        }

        // PUT: api/Administradors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministradors(int id, Administrador administradors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradors.AdministradorId)
            {
                return BadRequest();
            }

            try
            {
                administradorRepository.PutAdministrador(administradors);
                return Ok(administradors);
            }
            catch (Exception e)
            {
                return null;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Administradors
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult PostAdministradors(Administrador administradors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            administradorRepository.PostAdministrador(administradors);


            return CreatedAtRoute("DefaultApi", new { id = administradors.AdministradorId }, administradors);
        }

        // DELETE: api/Administradors/5
        [ResponseType(typeof(Administrador))]
        public IHttpActionResult DeleteAdministradors(int id)
        {
            Administrador administradors = administradorRepository.GetAdministrador(id);
            if (administradors == null)
            {
                return NotFound();
            }

            administradorRepository.DeleteAdministrador(administradors.AdministradorId);

            return Ok(administradors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                administradorRepository.GetDb();
            }
            base.Dispose(disposing);
        }
    }
}