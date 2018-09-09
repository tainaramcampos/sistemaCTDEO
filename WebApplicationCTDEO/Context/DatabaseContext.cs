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
            // customizando os campos da relação entre aluno e turma
            modelBuilder.Entity<Aluno>()
            .HasMany<Turma>(c => c.Turmas)
            .WithMany(c => c.Alunos)
            .Map(a => {
                a.ToTable("AlocacaoAluno");
                a.MapLeftKey("AlunoId");
                a.MapRightKey("TurmaId");
            });
            /*//relação entre aluno e familiar
            modelBuilder.Entity<Aluno>()
           .HasMany<Familiar>(c => c.Familiar)
           .WithMany(c => c.Alunos)
           .Map(a => {
               a.ToTable("Aluno_Familiar");
               a.MapLeftKey("AlunoId");
               a.MapRightKey("Familiar_Id");
           });*/

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Familiar> Familiar { get; set; }
        public DbSet<AlunoSocial> AlunoSocial { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Modalidade> Modalidade { get; set; }

    }
}