using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IAlunoRepository
    {
        List<Aluno> GetAlunos();
       

        Aluno PostAluno(Aluno aluno);
        Aluno PutAluno(Aluno aluno);

        Aluno GetAluno(int id);
        Aluno DeleteAluno(int id);
        void DeleteDisciplinasAluno(Aluno aluno);

        void PostDisciplinasAluno(Aluno aluno);

        List<DisciplinasAlunos> GetDisciplinaAluno(int AlunoId);







    }
}