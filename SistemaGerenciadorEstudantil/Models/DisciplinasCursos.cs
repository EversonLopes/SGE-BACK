using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGerenciadorEstudantil.Models
{
    public class DisciplinasCursos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }        
        public int CursoID_FK { get; set; }
        [ForeignKey("CursoID_FK")]
        public virtual Curso Curso { get; set; }
        
        public int DisciplinaID_FK { get; set; }
        [ForeignKey("DisciplinaID_FK")]
        public virtual Disciplina Disciplina { get; set; }
    }
}