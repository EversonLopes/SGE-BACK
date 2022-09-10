using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGerenciadorEstudantil.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }
        public string DisciplinaNome { get; set; }
        public List<DisciplinasAlunos> DisciplinasAlunos{get;set;}
        public List<DisciplinasCursos> DisciplinasCursos { get; set; }        
        public int ProfessorID_FK { get; set; }
        [ForeignKey("ProfessorID_FK")]
        public virtual Professor Professor { get; set; }                
       

    }
}