using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Repository.Contracts
{
    public interface IProfessorRepository
    {
        List<Professor> GetProfessores();
        Professor PostProfessor(Professor professor);
        Professor PutProfessor(Professor professor);
        Professor DeleteProfessor(int id);
        Professor GetProfessor(int id);
    }
}