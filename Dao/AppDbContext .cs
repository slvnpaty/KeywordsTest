using KeywordsTest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordsTest.Dao
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Card> Card { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<DepartamentByCard> DepartamentByCard { get; set; }
        public DbSet<TeamByCard> TeamByCard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Project>().Property(p => p.Name).HasMaxLength(100);

            modelBuilder.Entity<Project>().HasData(
                    new Project { Id = 1, Name = "Company" });



            modelBuilder.Entity<List>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<List>().HasData(
                    new List { Id = 1, Name = "Aguardando" },
                    new List { Id = 2, Name = "Em Andamento" },
                    new List { Id = 3, Name = "Pendência" },
                    new List { Id = 4, Name = "Finalizado" },
                    new List { Id = 5, Name = "Outros" });


            modelBuilder.Entity<Team>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Team>().HasData(
                    new Team { Id = 1, Name = "Financial Team", Abbreviation = "TF" },
                    new Team { Id = 2, Name = "Hypertext Preprocessor", Abbreviation = "PHP" },
                    new Team { Id = 3, Name = "Active Server Pages", Abbreviation = "ASP" },
                    new Team { Id = 4, Name = "Web designer", Abbreviation = "WD" });


            modelBuilder.Entity<Department>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Department>().HasData(
                    new Department { Id = 1, Name = "Financeiro" },
                    new Department { Id = 2, Name = "UX" },
                    new Department { Id = 3, Name = "UI" },
                    new Department { Id = 4, Name = "Desenvolvimento" });

            modelBuilder.Entity<Card>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<Card>().Property(p => p.Description).HasMaxLength(255);
            modelBuilder.Entity<Card>().HasData(
                    new Card { Id = 1, Name = "Criar Migration", ProjectId = 1, ListId = 1, Position = 1, Description = "Usar a branch Master,fazer pull, após isso...", Date = DateTime.Now },
                    new Card { Id = 2, Name = "Listagem Clientes", ProjectId = 1, ListId = 1, Position = 2, Description = "Colunas utilizadas: Código, Nome, Descrição", Date = DateTime.Now },
                    new Card { Id = 3, Name = "Lançar Notas", ProjectId = 1, ListId = 1, Position = 3, Description = "Selecionar notas fiscais, Lançar no ERP", Date = DateTime.Now });

            modelBuilder.Entity<TeamByCard>().HasData(
                  new TeamByCard { Id = 1, CardId = 1, TeamId = 2 },
                  new TeamByCard { Id = 2, CardId = 1, TeamId = 3 },
                  new TeamByCard { Id = 3, CardId = 1, TeamId = 4 },
                  new TeamByCard { Id = 4, CardId = 2, TeamId = 2 },
                  new TeamByCard { Id = 5, CardId = 3, TeamId = 1 });



            modelBuilder.Entity<DepartamentByCard>().HasData(
                  new DepartamentByCard { Id = 1, CardId = 1, DepartmentId = 4 },
                  new DepartamentByCard { Id = 2, CardId = 2, DepartmentId = 2 },
                  new DepartamentByCard { Id = 3, CardId = 2, DepartmentId = 3 },
                  new DepartamentByCard { Id = 4, CardId = 3, DepartmentId = 1 });



        }

    }
}
