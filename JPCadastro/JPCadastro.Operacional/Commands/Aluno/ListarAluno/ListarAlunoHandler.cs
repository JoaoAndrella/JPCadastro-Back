using JPCadastro.Core.DTOs;
using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Operacional.Commands.Aluno.ListarAluno
{
    public class ListarAlunoHandler : Notifiable,
        IRequestHandler<ListarAlunoRequest, CommandResponse>
    {
        private readonly IRepositoryAluno _repositoryAluno;

        public ListarAlunoHandler(IRepositoryAluno repositoryAluno)
        {
            _repositoryAluno=repositoryAluno;
        }

        public Task<CommandResponse> Handle(ListarAlunoRequest request,
            CancellationToken cancellationToken)
        {

            //TESTANDO SE O ALUNO JÁ ESTA CADASTRADO
            var colecaoAluno = _repositoryAluno.ListarSemRastreamento();

            return Task.FromResult(new CommandResponse(colecaoAluno.Select(p => new ListarAlunoResponse
            {
                Cpf = p.Cpf,
                Nome = p.Nome,
                Telefone = p.Telefone
            }), this));
        }
    }
}
