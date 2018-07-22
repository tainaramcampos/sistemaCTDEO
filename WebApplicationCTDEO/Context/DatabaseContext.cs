using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplicationCTDEO.Models;

namespace WebApplicationCTDEO.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("CTDatabase") { }

        //removendo a convenção de pluralizar os nomes das tabelas
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //adicionando a relação entre aluno e turma
            modelBuilder.Entity<Aluno>()
            .HasMany(c => c.Turmas)
            .WithMany(c => c.Alunos)
            .Map(a => {
                a.ToTable("AlocacaoAluno");
                a.MapLeftKey("AlunoId");
                a.MapRightKey("Turma_Id");
            });

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Familiares> Familiar { get; set; }
        public DbSet<AlunoSocial> AlunoSocial { get; set; }
        public DbSet<Responsavel> Pais { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Modalidade> Modalidade { get; set; }

    }
}