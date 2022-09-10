using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGerenciadorEstudantil.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string CursoNome { get; set; }        
        public ICollection<Aluno> Alunos { get; set; }
        public List<DisciplinasCursos> DisciplinasCursos { get; set; }

    }
}