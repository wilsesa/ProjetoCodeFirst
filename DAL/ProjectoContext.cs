using ProjetoCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoCodeFirst.DAL
{
    public class ProjectoContext : DbContext
    {
        public ProjectoContext() : base("CFConnectionString"){ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Universidade> Universidades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}