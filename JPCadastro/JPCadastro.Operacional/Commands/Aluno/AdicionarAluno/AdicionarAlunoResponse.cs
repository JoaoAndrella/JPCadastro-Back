namespace JPCadastro.Operacional.Commands.Aluno.AdicionarAluno
{
    public class AdicionarAlunoResponse
    {
        public string Cpf { get; }
        public string Mensagem { get; }

        public AdicionarAlunoResponse(string cpf, string mensagem)
        {
            Cpf=cpf;
            Mensagem=mensagem;
        }
    }
}
