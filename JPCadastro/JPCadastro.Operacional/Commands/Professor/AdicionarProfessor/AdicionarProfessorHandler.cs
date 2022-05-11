using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Commands.Aluno.AdicionarProfessor;
using JPCadastro.Operacional.Entities.Professor;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Professor.AdicionarProfessor
{
    public class AdicionarProfessorHandler : Notifiable,
        IRequestHandler<AdicionarProfessorRequest, CommandResponse>
    {
        private readonly IRepositoryProfessor _repositoryProfessor;

        public AdicionarProfessorHandler(IRepositoryProfessor repositoryProfessor)
        {
            _repositoryProfessor=repositoryProfessor;
        }

        public Task<CommandResponse> Handle(AdicionarProfessorRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarProfessorHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O Professor JÁ ESTA CADASTRADO
            var professor = _repositoryProfessor.ObterPorId(request.Cpf);
            if (professor!=null)
            {
                AddNotification("AdicionarProfessorHandler", "Professor Já Está Cadastrado");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT Professor
            professor = new ProfessorEntity(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(professor);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryProfessor.Adcionar(professor);

            return Task.FromResult(new CommandResponse(new AdicionarProfessorResponse(
                professor.Id, professor.Nome, "Professor Cadastrado Com Sucesso"), this));
        }
    }
}
