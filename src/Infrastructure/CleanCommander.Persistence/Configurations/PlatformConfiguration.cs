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
    public class PlatformConfiguration : IEntityTypeConfiguration<PromptPlatform>
    {
        public void Configure(EntityTypeBuilder<PromptPlatform> builder)
        {
            builder.Property(e => e.PromptPlatformName)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}
