﻿using JovemProgramadorMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JovemProgramadorMVC.Data.Mapeamento
{
    public class ProfessorMapping : IEntityTypeConfiguration<ProfessorModel>
    {
        public void Configure(EntityTypeBuilder<ProfessorModel> builder)
        {
            builder.ToTable("Professor");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(50)");
            builder.Property(t => t.Idade).HasColumnType("int");
            builder.Property(t => t.Contato).HasColumnType("varchar(15)");
            builder.Property(t => t.Email).HasColumnType("varchar(50)");
            builder.Property(t => t.Cep).HasColumnType("varchar(10)");
        }
    }
}
