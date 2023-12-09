using Microsoft.AspNetCore.Mvc;
using Montreal.IdNet.Obito.Application.Services.Interfaces;
using Montreal.IdNet.Obito.Application.ViewModels;
using System;
using System.Threading.Tasks;
using TSystems.Core.Crosscutting.Domain.Bus;
using TSystems.Core.Crosscutting.Domain.Controller;

namespace Montreal.IdNet.Obito.API.Controllers
{
    [Route("api/v1/demo")]
    [ApiController]
    public class DemoController : ApiController
    {
        private readonly IDemoApplicationService _demoApplicationService;

        public DemoController(IMediatorHandler mediator,
                              IDemoApplicationService demoApplicationService) : base(mediator)
        {
            _demoApplicationService = demoApplicationService;
        }

        [HttpGet("{demoId}")]
        public async Task<IActionResult> GetByIdAsync(Guid demoId)
        {
            return Response(await _demoApplicationService.GetByIdAsync(demoId));
        }

        /// <summary>
        /// Criar um demo
        /// </summary>
        /// <param name="demoViewModel">Dados de entrada para o cadastro</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DemoViewModel demoViewModel)
        {
            await _demoApplicationService.AddAsync(demoViewModel);
            return Response();
        }

        /// <summary>
        /// Editar um produto
        /// </summary>
        /// <param name="demoId">Demo Id </param>
        /// <param name="demoViewModel">Dados de entrada para o cadastro</param>
        [HttpPut("{demoId}")]
        public async Task<IActionResult> Update(Guid demoId, [FromBody] DemoViewModel demoViewModel)
        {
            await _demoApplicationService.UpdateAsync(demoId, demoViewModel);
            return Response();
        }

        /// <summary>
        /// Inativar um produto
        /// </summary>
        /// <response code="200">Item deleted</response>
        /// <response code="404">Item not found</response>
        /// <param name="demoId">Demo Id</param>
        [HttpDelete("{demoId}")]
        public async Task<IActionResult> Delete(Guid demoId)
        {
            await _demoApplicationService.DeleteAsync(demoId);
            return Response();
        }

    }
}
