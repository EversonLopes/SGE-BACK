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
    public class AdminstradorRepository : IAdministradorRepository
    {
        private SGEContext db = new SGEContext();



        // DELETE: api/Administradors/5

        public Administrador DeleteAdministrador(int id)
        {
            try
            {
                var administrador = GetAdministrador(id);

                if (administrador == null)
                {
                    throw new Exception("Administrador não encontrado");
                }

                db.Administradores.Remove(administrador);
                db.SaveChanges();

                return administrador;

            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        // GET: api/Admnistradors
        public Administrador GetAdministrador(int id)
        {
            try
            {
                return db.Administradores.Where(c => c.AdministradorId == id).FirstOrDefault();
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

        public List<Administrador> GetAdministradores()
        {

            try
            {
                return db.Administradores.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Administrador PostAdministrador(Administrador administrador)
        {
            try
            {
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return administrador;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public Administrador PutAdministrador(Administrador administrador)
        {
            try
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return administrador;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }




    }
}





