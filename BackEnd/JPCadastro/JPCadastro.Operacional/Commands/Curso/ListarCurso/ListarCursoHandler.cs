﻿using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.ListarCurso
{
    public class ListarCursoHandler : Notifiable,
        IRequestHandler<ListarCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;
        
        public ListarCursoHandler(IRepositoryCurso repositoryCurso)
        {
            _repositoryCurso=repositoryCurso;
        }

        public Task<CommandResponse> Handle(ListarCursoRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O Curso JÁ ESTA CADASTRADO
            var colecaoCurso = _repositoryCurso.ListarSemRastreamento(p => p.Professor);

            return Task.FromResult(new CommandResponse(colecaoCurso.Select(p => new ListarCursoResponse
            {
                Id= p.Id,
                Nome= p.Nome,
                Periodo=  p.Periodo,
                ProfessorId= p.ProfessorId,
                PorfessorNome=p.ProfessorNome
            }), this));
        }
    }
}