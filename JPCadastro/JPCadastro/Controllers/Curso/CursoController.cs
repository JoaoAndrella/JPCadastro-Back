﻿using JPCadastro.Controllers.Base;
using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Operacional.Commands.Curso.Atualizar;
using JPCadastro.Operacional.Commands.Curso.AtualizarCurso;
using JPCadastro.Operacional.Commands.Curso.ListarCurso;
using JPCadastro.Operacional.Commands.Curso.ObterCurso;
using JPCadastro.Operacional.Commands.Curso.RemoverCurso;
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

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar(AtualizarCursoRequest request)
        {
            return JPPutActionResult(await _mediator.Send(request));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            return JPGetActionResult(await _mediator.Send(new ListarCursoRequest()));
        }

        [HttpGet("obter")]
        public async Task<IActionResult> Obter([FromQuery] Guid id)
        {
            return JPGetActionResult(await _mediator.Send(new ObterCursoRequest(id)));
        }

        [HttpDelete("remover")]
        public async Task<IActionResult> Remover([FromQuery] Guid id)
        {
            return JPDeletActionResult(await _mediator.Send(new RemoverCursoRequest(id)));
        }
    }
}
