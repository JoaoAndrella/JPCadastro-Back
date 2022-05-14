using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Curso.Atualizar;
using JPCadastro.Operacional.Entities.Curso;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Curso.AdicionarCurso
{
    public class AdicionarCursoHandler : Notifiable,
        IRequestHandler<AdicionarCursoRequest, CommandResponse>
    {
        private readonly IRepositoryCurso _repositoryCurso;
        private readonly IRepositoryProfessor _repositoryProfessor;

        public AdicionarCursoHandler(IRepositoryCurso repositoryCurso, IRepositoryProfessor repositoryProfessor)
        {
            _repositoryCurso=repositoryCurso;
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(AdicionarCursoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarCursoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //Verificando se o Professor Existe

            if (request.ProfessorId!=null)
            {
                if (!_repositoryProfessor.Existe(p => p.Id == request.ProfessorId))
                {
                    AddNotification("AdicionarCursoHandler", "Professor não Localizado");
                    return Task.FromResult(new CommandResponse(this));
                }
            }

            if (request.ProfessorNome!=null)
            {
                if (!_repositoryProfessor.Existe(p => p.Nome == request.ProfessorNome))
                {
                    AddNotification("AdicionarCursoHandler", "Professor não Localizado");
                    return Task.FromResult(new CommandResponse(this));
                }
            }

            var curso = new CursoEntity(
                 request.Nome,
                 request.Periodo,
                 request.ProfessorId,
                 request.ProfessorNome
                 );
            AddNotifications(curso);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryCurso.Adcionar(curso);

            return Task.FromResult(new CommandResponse(new AdicionarCursoResponse(
                curso.Id, curso.Nome, "Curso Cadastrado Com Sucesso"), this));
        }
    }
}
