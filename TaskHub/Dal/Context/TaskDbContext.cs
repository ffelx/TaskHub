using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Context;

public sealed class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
    : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", t => t.ExcludeFromMigrations());

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            entity.Property(x => x.LastActivityUtc)
                .HasColumnName("last_activity_utc")
                .IsRequired();
        });

        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Title)
                .HasColumnName("title")
                .HasMaxLength(200);

            entity.Property(t => t.CreatedByUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();

            entity.Property(t => t.CreatedUtc)
                .HasColumnName("created_utc")
                .IsRequired();

            entity.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId);
        });

        


        base.OnModelCreating(modelBuilder);
    }


}
