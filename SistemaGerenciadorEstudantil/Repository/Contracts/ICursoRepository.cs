using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;


namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface ICursoRepository
    {
        List<Curso> GetCursos();
        Curso PostCurso(Curso curso);
        Curso PutCurso(Curso curso);
        Curso DeleteCurso(int id);
        Curso GetCurso(int id);
        void PostDisciplinasCurso(Curso curso);
        void DeleteDisciplinasCurso(Curso curso);
        List<DisciplinasCursos> GetDisciplinasCurso(int CursoId);
    }
}