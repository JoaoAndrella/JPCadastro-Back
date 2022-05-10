using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Aluno.RemoverAluno
{
    public class RemoverAlunoRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; }

        public RemoverAlunoRequest(string cpf)
        {
            Cpf=cpf;
        }
    }
}
