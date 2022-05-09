﻿using JPCadastro.Core.DTOs;
using JPCadastro.Core.Interfaces.UoW;
using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        protected BaseController(IUnitOfWork uow)
        {
            _uow=uow;
        }

        protected IActionResult JPPostActionResult(CommandResponse commandResponse)
        {
            if (!commandResponse.Sucesso)
                return BadRequest(commandResponse);

            var commitResult = _uow.Commit();
            if (commitResult.Sucesso)
                return Created("", commandResponse);

            return TratativaErroPersistencia(commitResult);
        }

        private IActionResult TratativaErroPersistencia(CommitResult commitResult)
        {
            var erroResponse = new List<Notification>
            {
                new Notification("Persitência", commitResult.MensagemErroDetalhada != null
                    ? $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro} - {commitResult.MensagemErroDetalhada}"
                    : $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro}")

            };
            return BadRequest(new
            {
                Sucesso = false,
                Notificacoes = erroResponse
            });
        }
    }       
}
