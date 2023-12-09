using Montreal.IdNet.Obito.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Montreal.IdNet.Obito.Domain.Services.Interfaces
{
    public interface IDemoDomainService
    {
        Task<Demo> GetByIdAsync(Guid id);
        Task AddAsync(Demo demo);
        Task UpdateAsync(Guid demoId, Demo demo);
        Task DeleteAsync(Guid demoId);
    }
}
