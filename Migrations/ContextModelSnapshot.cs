﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace OnFit.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEquipamentos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipamentoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Models.Exercicio", b =>
                {
                    b.Property<int>("ExercicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<string>("ExercicioNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FichaId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoMuscular")
                        .HasColumnType("int");

                    b.Property<int>("Repeticoes")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.HasKey("ExercicioId");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("FichaId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("Models.Ficha", b =>
                {
                    b.Property<int>("FichaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("FichaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Fichas");
                });

            modelBuilder.Entity("Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cref")
                        .HasColumnType("float");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("ProfessorEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlunoEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("Models.Aluno", b =>
                {
                    b.HasBaseType("Models.Usuario");

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<string>("AlunoNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Objetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasIndex("ProfessorId");

                    b.HasDiscriminator().HasValue("Aluno");
                });

            modelBuilder.Entity("Models.Exercicio", b =>
                {
                    b.HasOne("Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId");

                    b.HasOne("Models.Ficha", null)
                        .WithMany("itens")
                        .HasForeignKey("FichaId");

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("Models.Ficha", b =>
                {
                    b.HasOne("Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Aluno");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Models.Aluno", b =>
                {
                    b.HasOne("Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Models.Ficha", b =>
                {
                    b.Navigation("itens");
                });
#pragma warning restore 612, 618
        }
    }
}
