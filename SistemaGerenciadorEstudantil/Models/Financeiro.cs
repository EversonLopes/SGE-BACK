using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGerenciadorEstudantil.Models
{
    public class Financeiro
    {
        [Key]
        public int FinanceiroId { get; set; }
        public bool Quitado { get; set; }
        public double ValorTotal { get; set; }
        public double Mensalidade { get; set; }
        public Aluno Aluno { get; set; }
    }
}