using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Montreal.IdNet.Obito.Domain.Entity;
using TSystems.Core.Crosscutting.Infrastructure.Mappings.Base.V2;

namespace Montreal.IdNet.Obito.Infrastructure.Mappings
{
    public class DemoConfig : BaseMap<Demo>
    {
        public override void Configure(EntityTypeBuilder<Demo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.ToTable("Demo");
        }
    }
}
