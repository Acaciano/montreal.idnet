using Montreal.IdNet.Obito.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Montreal.IdNet.Obito.Application.Services.Interfaces
{
    public interface IDemoApplicationService
    {
        Task<DemoViewModel> GetByIdAsync(Guid id);
        Task AddAsync(DemoViewModel demo);
        Task UpdateAsync(Guid demoId, DemoViewModel demo);
        Task DeleteAsync(Guid demoId);
    }
}
