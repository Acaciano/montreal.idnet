using AutoMapper;
using Montreal.IdNet.Obito.Application.Services.Interfaces;
using Montreal.IdNet.Obito.Application.ViewModels;
using Montreal.IdNet.Obito.Domain.Entity;
using Montreal.IdNet.Obito.Domain.Services.Interfaces;
using Montreal.IdNet.Obito.Infrastructure.Contexts;
using System;
using System.Threading.Tasks;
using TSystems.Core.Crosscutting.Domain.ApplicationService;
using TSystems.Core.Crosscutting.Domain.Bus;
using TSystems.Core.Crosscutting.Domain.UnitOfWork;

namespace TSystemsTemplate.Application.Services
{
    public class DemoApplicationService : BaseService<MontrealIdNetObitoContext>, IDemoApplicationService
    {
        private readonly IUnitOfWork<MontrealIdNetObitoContext> _unitOfWork;
        private readonly IDemoDomainService _demoDomainService;
        private readonly IMapper _mapper;

        public DemoApplicationService(IMediatorHandler mediatorHandler,
                              IUnitOfWork<MontrealIdNetObitoContext> unitOfWork,
                              IMapper mapper,
                              IDemoDomainService demoDomainService) : base(mediatorHandler, unitOfWork)
        {
            this._demoDomainService = demoDomainService;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public async Task<DemoViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<DemoViewModel>(await _demoDomainService.GetByIdAsync(id));
        }

        public async Task AddAsync(DemoViewModel demo)
        {
            await _demoDomainService.AddAsync(_mapper.Map<Demo>(demo));
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid demoId, DemoViewModel demo)
        {
            await _demoDomainService.UpdateAsync(demoId, _mapper.Map<Demo>(demo));
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid demoId)
        {
            await _demoDomainService.DeleteAsync(demoId);
            await _unitOfWork.CommitAsync();
        }
    }
}
