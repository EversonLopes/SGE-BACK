using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Enums;

namespace SistemaGerenciadorEstudantil.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }    
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public NiveldePermissaoEnum NiveldePermissaoEnum { get; set; }        

        public List<DisciplinasAlunos> DisciplinasAlunos{get; set;}
        public int CursoID_FK { get; set; } 
        [ForeignKey("CursoID_FK")]
        public virtual Curso Curso { get; set; }    
    }

    
}