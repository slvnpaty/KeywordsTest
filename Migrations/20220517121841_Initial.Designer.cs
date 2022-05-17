﻿// <auto-generated />
using System;
using KeywordsTest.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeywordsTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220517121841_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KeywordsTest.Model.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Card");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 5, 17, 9, 18, 41, 503, DateTimeKind.Local).AddTicks(5618),
                            Description = "Usar a branch Master,fazer pull, após isso...",
                            ListId = 1,
                            Name = "Criar Migration",
                            Position = 1,
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2022, 5, 17, 9, 18, 41, 504, DateTimeKind.Local).AddTicks(9430),
                            Description = "Colunas utilizadas: Código, Nome, Descrição",
                            ListId = 1,
                            Name = "Listagem Clientes",
                            Position = 2,
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2022, 5, 17, 9, 18, 41, 504, DateTimeKind.Local).AddTicks(9453),
                            Description = "Selecionar notas fiscais, Lançar no ERP",
                            ListId = 1,
                            Name = "Lançar Notas",
                            Position = 3,
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.DepartamentByCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DepartamentByCard");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 1,
                            DepartmentId = 4
                        },
                        new
                        {
                            Id = 2,
                            CardId = 2,
                            DepartmentId = 2
                        },
                        new
                        {
                            Id = 3,
                            CardId = 2,
                            DepartmentId = 3
                        },
                        new
                        {
                            Id = 4,
                            CardId = 3,
                            DepartmentId = 1
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Financeiro"
                        },
                        new
                        {
                            Id = 2,
                            Name = "UX"
                        },
                        new
                        {
                            Id = 3,
                            Name = "UI"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Desenvolvimento"
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("List");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aguardando"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Em Andamento"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pendência"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Finalizado"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Outros"
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Company"
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "TF",
                            Name = "Financial Team"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "PHP",
                            Name = "Hypertext Preprocessor"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "ASP",
                            Name = "Active Server Pages"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "WD",
                            Name = "Web designer"
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.TeamByCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamByCard");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardId = 1,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 2,
                            CardId = 1,
                            TeamId = 3
                        },
                        new
                        {
                            Id = 3,
                            CardId = 1,
                            TeamId = 4
                        },
                        new
                        {
                            Id = 4,
                            CardId = 2,
                            TeamId = 2
                        },
                        new
                        {
                            Id = 5,
                            CardId = 3,
                            TeamId = 1
                        });
                });

            modelBuilder.Entity("KeywordsTest.Model.Card", b =>
                {
                    b.HasOne("KeywordsTest.Model.List", "List")
                        .WithMany()
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeywordsTest.Model.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("KeywordsTest.Model.Department", b =>
                {
                    b.HasOne("KeywordsTest.Model.Card", null)
                        .WithMany("Department")
                        .HasForeignKey("CardId");
                });

            modelBuilder.Entity("KeywordsTest.Model.Team", b =>
                {
                    b.HasOne("KeywordsTest.Model.Card", null)
                        .WithMany("Teams")
                        .HasForeignKey("CardId");
                });

            modelBuilder.Entity("KeywordsTest.Model.TeamByCard", b =>
                {
                    b.HasOne("KeywordsTest.Model.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("KeywordsTest.Model.Card", b =>
                {
                    b.Navigation("Department");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
