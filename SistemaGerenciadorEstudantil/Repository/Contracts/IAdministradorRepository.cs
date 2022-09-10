using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IAdministradorRepository
    {
        List<Administrador> GetAdministradores();
        Administrador PostAdministrador(Administrador administrador);
        Administrador PutAdministrador(Administrador administrador);
        Administrador DeleteAdministrador(int id);
        Administrador GetAdministrador(int id);
        
    }
}