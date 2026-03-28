using Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    internal class TaskDbContextFactory : IDesignTimeDbContextFactory<TaskDbContext>
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=taskhub;Username=postgres;Password=postgres";

        public TaskDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();

            optionsBuilder.UseNpgsql(ConnectionString);

            return new TaskDbContext(optionsBuilder.Options);
        }
    }
}
