using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> GetFuncionarios();
        Funcionario PostFuncionario(Funcionario funcionario);
        Funcionario PutFuncionario(Funcionario funcionario);
        Funcionario DeleteFuncionario(int id);
        Funcionario GetFuncionario(int id);
    }
}