﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopeeKorean.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<global::Repository.RepositoryContext>
    {
        public global::Repository.RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<global::Repository.RepositoryContext>()
               .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
               b => b.MigrationsAssembly("ShopeeKorean.Application"));
            return new global::Repository.RepositoryContext(builder.Options);
        }
    }
}