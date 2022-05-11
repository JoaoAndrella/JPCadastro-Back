using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Professor.RemoverProfessor
{
    public class RemoverProfessorRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; }
        public RemoverProfessorRequest(string cpf)
        {
            Cpf=cpf; 
        }

    }
}
