using CleanCommander.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Configurations
{
    public class CommandConfiguration : IEntityTypeConfiguration<CommandLine>
    {
        public void Configure(EntityTypeBuilder<CommandLine> builder)
        {
            builder.Property(e => e.PromptPlatformName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Line)
                .IsRequired();

            builder.Property(e => e.HowTo)
                .IsRequired();
        }
    }
}
