using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Curso.Atualizar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers.Curso
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : BaseController
    {
        private readonly IMediator _mediator;
        public CursoController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator=mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarCursoRequest request)
        {
            return JPPostActionResult(await _mediator.Send(request));
        }
    }
}
