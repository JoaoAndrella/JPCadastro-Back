﻿using JPCadastro.Core.DTOs;
using MediatR;

namespace JPCadastro.Operacional.Commands.Professor.AtualizarProfessor
{
    public class AtualizarProfessorRequest : IRequest<CommandResponse>
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
