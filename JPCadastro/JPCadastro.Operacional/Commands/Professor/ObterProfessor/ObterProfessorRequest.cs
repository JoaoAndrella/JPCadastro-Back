using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Professor.ObterProfessor
{
    public class ObterProfessorRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; set; }
        public ObterProfessorRequest(string cpf)
        {
            Cpf=cpf;
        }
    }
}
