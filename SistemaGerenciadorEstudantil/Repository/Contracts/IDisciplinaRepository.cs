using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;


namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IDisciplinaRepository
    {
        List<Disciplina> GetDisciplinas();
        Disciplina PostDisciplina(Disciplina disciplina);
        Disciplina PutDisciplina(Disciplina disciplina);
        Disciplina DeleteDisciplina(int id);
        Disciplina GetDisciplina(int id);

    }
}