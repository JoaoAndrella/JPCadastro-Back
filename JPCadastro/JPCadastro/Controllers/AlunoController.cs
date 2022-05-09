using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Aluno.AdicionarAluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers
{
    public class AlunoController : BaseController
    {
        private readonly IMediator _mediator;

        public AlunoController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator=mediator;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar(AdicionarAlunoRequest request)
        {
            return JPPostActionResult(await _mediator.Send(request));
        }

        //   [HttpPut("atualizar")]
        //  public async Task<IActionResult> Atualizar()
    }
}
