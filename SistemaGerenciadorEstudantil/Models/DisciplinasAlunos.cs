using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGerenciadorEstudantil.Models
{
    public class DisciplinasAlunos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int AlunoID_FK { get; set; }
        [ForeignKey("AlunoID_FK")]
        public virtual Aluno Aluno { get; set; }        
        public int DisciplinaID_FK { get; set; }
        [ForeignKey("DisciplinaID_FK")]
        public virtual Disciplina Disciplina { get; set; }      
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public int MediaFinal { get; set; }
        public bool DisciplinaAprovado { get; set; }

    }
}