using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SistemaGerenciadorEstudantil.Enums;

namespace SistemaGerenciadorEstudantil.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public NiveldePermissaoEnum NiveldePermissaoEnum { get; set; }

    }
}