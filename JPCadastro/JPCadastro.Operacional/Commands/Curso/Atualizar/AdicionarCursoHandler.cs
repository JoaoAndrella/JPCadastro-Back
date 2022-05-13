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
            var professor = _repositoryProfessor.ObterPorId(request.ProfessorId);
            if (professor==null)
            {
                AddNotification("AdicionarCursoHandler", "Professor não localizado");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT Curso
            var curso = new CursoEntity(
                 request.Nome,
                 request.Periodo,
                 request.ProfessorId
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
