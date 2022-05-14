using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.ListarCurso
{
    public class ListarCursoHandler : Notifiable,
        IRequestHandler<ListarCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;
        private readonly IRepositoryProfessor _repositoryProfessor;

        public ListarCursoHandler(IRepositoryCurso repositoryCurso)
        {
            _repositoryCurso=repositoryCurso;
        }

        public Task<CommandResponse> Handle(ListarCursoRequest request,
            CancellationToken cancellationToken)
        {
            //TESTANDO SE O Curso JÁ ESTA CADASTRADO
            var colecaoCurso = _repositoryCurso.ListarPorSemRastreamento(p => p.ProfessorId == request.ProfessorId, p => p.Professor).ToList();

            var listarCursoResponse = colecaoCurso.Select(p => new ListarCursoResponse
            {
                Id= p.Id,
                Nome= p.Nome,
                Periodo=  p.Periodo,
                ProfessorId= p.ProfessorId,
                PorfessorNome=p.ProfessorNome
            });

            return Task.FromResult(new CommandResponse(listarCursoResponse, this));
        }
    }
}
