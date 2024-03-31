using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence
{
    public class CleanCommanderDbContext : DbContext
    {
        public CleanCommanderDbContext(DbContextOptions<CleanCommanderDbContext> options)
           : base(options)
        {
        }

        public DbSet<CommandLine> CommandLines { get; set; }
        public DbSet<PromptPlatform> PromptPlatforms { get; set; }
        //public DbSet<PlatformImage> PlatformImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanCommanderDbContext).Assembly);

            //seed data, added through migrations
            var angularCliGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var efGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var gitGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            modelBuilder.Entity<PromptPlatform>().HasData(new PromptPlatform
            {
                PromptPlatformName = "Angular CLI",
                PromptPlatformId = angularCliGuid 
            });
            modelBuilder.Entity<PromptPlatform>().HasData(new PromptPlatform
            {
                PromptPlatformName = "Entity Framework",
                PromptPlatformId = efGuid
            });
            modelBuilder.Entity<PromptPlatform>().HasData(new PromptPlatform
            {
                PromptPlatformName = "Git commands",
                PromptPlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"), 
                PromptPlatformName = "Angular CLI", 
                HowTo = "Generate new module", 
                Line = "This is the command", 
                Comment = "This is a comment", 
                PromptPlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                PromptPlatformName = "Angular CLI",
                HowTo = "Generate new component",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                PromptPlatformName = "Angular CLI",
                HowTo = "Generate new Service",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = angularCliGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                PromptPlatformName = "Entity Framework",
                HowTo = "Add new migratation",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = efGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                PromptPlatformName = "Entity Framework",
                HowTo = "Update database",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = efGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                PromptPlatformName = "Entity Framework",
                HowTo = "Update packages",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = efGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                PromptPlatformName = "Git commands",
                HowTo = "Push code",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                PromptPlatformName = "Git commands",
                HowTo = "Change branch",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = gitGuid
            });

            modelBuilder.Entity<CommandLine>().HasData(new CommandLine
            {
                CommandLineId = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                PromptPlatformName = "Git commands",
                HowTo = "Add new repository",
                Line = "This is the command",
                Comment = "This is a comment",
                PromptPlatformId = gitGuid
            });
        }
        }
}
