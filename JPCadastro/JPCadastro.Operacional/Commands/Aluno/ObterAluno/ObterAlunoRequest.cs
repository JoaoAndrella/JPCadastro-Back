using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Aluno.ObterAluno
{
    public class ObterAlunoRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; }
        public ObterAlunoRequest(string cpf)
        {
            Cpf = cpf;
        }
    }
}
