namespace JPCadastro.Operacional.Commands.Aluno.AtualizarAluno
{
    public class AtualizarAlunoResponse
    {
        public string Cpf { get; }
        public string Mensagem { get; }

        public AtualizarAlunoResponse(string cpf, string mensagem)
        {
            Cpf=cpf;
            Mensagem=mensagem;
        }
    }
}
