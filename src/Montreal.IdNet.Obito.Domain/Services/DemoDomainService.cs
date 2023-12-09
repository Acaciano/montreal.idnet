using Montreal.IdNet.Obito.Domain.Entity;
using Montreal.IdNet.Obito.Domain.Exceptions;
using Montreal.IdNet.Obito.Domain.Repositories.Interfaces;
using Montreal.IdNet.Obito.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;
using TSystems.Core.Crosscutting.Domain.Bus;
using TSystems.Core.Crosscutting.Domain.DomainService;

namespace Montreal.IdNet.Obito.Domain.Services
{
    public class DemoDomainService : BaseService<Demo>, IDemoDomainService
    {
        private readonly IDemoRepository _demoRepository;

        public DemoDomainService(IMediatorHandler mediatorHandler,
                                 IDemoRepository repository) : base(mediatorHandler, repository)
        {
            _demoRepository = repository;
        }

        public async Task<Demo> GetByIdAsync(Guid id) => await _demoRepository.GetByIdAsync(id);

        public async Task AddAsync(Demo demo) => await _demoRepository.InsertOrUpdateAsync(demo);

        public async Task UpdateAsync(Guid demoId, Demo demo)
        {
            try
            {
                var findById = await GetByIdAsync(demoId);

                if (findById != null)
                {
                    findById.SetName(demo.Name);
                    findById.SetDescription(demo.Description);

                    await _demoRepository.InsertOrUpdateAsync(findById);
                }

                await _mediator.NotifyError($"Não encontramos nenhum demo para o ID: {demoId}");
                return;
            }
            catch (DomainException ex)
            {
                await _mediator.NotifyError(ex.Message);
            }
        }

        public async Task DeleteAsync(Guid demoId) => await _demoRepository.DeleteByIdAsync(demoId);
    }
}
