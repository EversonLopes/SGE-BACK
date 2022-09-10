using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SistemaGerenciadorEstudantil.Models;

namespace SistemaGerenciadorEstudantil.Database
{
    public class SGEContext : DbContext
    {
        //Construitor da classe, no qual é definido suas propriedades no arquivo web.config
        public SGEContext() : base("name=SGEContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Criação das chaves para as tabelas com associação muitos para muitos
            modelBuilder.Entity<DisciplinasAlunos>().HasKey(vt => new { vt.AlunoID_FK, vt.DisciplinaID_FK,  vt.Id });
            modelBuilder.Entity<DisciplinasCursos>().HasKey(tc => new { tc.CursoID_FK, tc.DisciplinaID_FK, tc.Id });
        }

        //Modelos que serão espelhadas no banco de dados
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Professor> Professores { get; set; }        
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinasAlunos> DisciplinasAlunos { get; set; }
        public DbSet<DisciplinasCursos> DisciplinasCursos { get; set; }
        public DbSet<Financeiro> Financeiros { get; set; }
        
       


    }

}
