using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Montreal.IdNet.Obito.Infrastructure.Contexts;
using System;
using TSystems.Core.Crosscutting.Bus;
using TSystems.Core.Crosscutting.Common.Excel;
using TSystems.Core.Crosscutting.Domain.Bus;
using TSystems.Core.Crosscutting.Domain.Notifications;
using TSystems.Core.Crosscutting.Domain.UnitOfWork;
using TSystems.Core.Crosscutting.Infrastructure.UnitOfWork;

namespace Montreal.IdNet.Obito.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IUnitOfWork<MontrealIdNetObitoContext>, UnitOfWork<MontrealIdNetObitoContext>>();
            services.AddScoped<IExcelService, ExcelService>();

            services.Scan(s => s
               .FromApplicationDependencies(a => a.FullName.StartsWith("Montreal.IdNet.Obito"))
               .AddClasses().AsMatchingInterface((service, filter) =>
                   filter.Where(i => i.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase))).WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(IMediator))).AsImplementedInterfaces().WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<,>))).AsImplementedInterfaces().WithScopedLifetime()
               .AddClasses(x => x.AssignableTo(typeof(INotificationHandler<>))).AsImplementedInterfaces().WithScopedLifetime()
            );

            services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext?.User);
        }
    }
}