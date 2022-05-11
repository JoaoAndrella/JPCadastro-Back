using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.AdicionarAluno
{
    public class AdicionarAlunoHandler : Notifiable,
        IRequestHandler<AdicionarAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;

        public AdicionarAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(AdicionarAlunoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O REQUEST É NULO
            if (request==null)
            {
                AddNotification("AdicionarAlunoHandler", "Request é Obrigatório");
                return Task.FromResult(new CommandResponse(this));
            }

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var aluno = _repositoryAluno.ObterPorId(request.Cpf);
            if (aluno!=null)
            {
                AddNotification("AdicionarAlunoHandler", "Aluno Já Está Cadastrado");
                return Task.FromResult(new CommandResponse(this));
            }

            //CRIANDO O OBJT ALUNO
            aluno = new AlunoEntity(
                request.Cpf,
                request.Nome,
                request.Telefone
                );
            AddNotifications(aluno);

            if (IsInvalid())
                return Task.FromResult(new CommandResponse(this));

            _repositoryAluno.Adcionar(aluno);

            return Task.FromResult(new CommandResponse(new AdicionarAlunoResponse(
                aluno.Id, "Aluno Cadastrado Com Sucesso"), this));
        }
    }
}
