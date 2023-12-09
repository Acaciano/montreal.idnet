using Montreal.IdNet.Obito.Domain.Entity;
using Montreal.IdNet.Obito.Domain.Repositories.Interfaces;
using Montreal.IdNet.Obito.Infrastructure.Contexts;
using TSystems.Core.Crosscutting.Infrastructure.Repositories.V2;

namespace Montreal.IdNet.Obito.Infrastructure.Repositories
{
    public class DemoRepository : Repository<Demo>, IDemoRepository
    {
        public DemoRepository(MontrealIdNetObitoContext context)
            : base(context) { }
    }
}
