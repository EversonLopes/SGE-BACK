using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IFinanceiroRepository
    {
        List<Financeiro> GetFinanceiros();
        Financeiro PostFinanceiro(Financeiro financeiro);
        Financeiro PutFinanceiro(Financeiro financeiro);
        Financeiro DeleteFinanceiro(int id);
        Financeiro GetFinanceiro(int id);
    }
}