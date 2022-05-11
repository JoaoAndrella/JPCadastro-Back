namespace JPCadastro.Operacional.Commands.Professor.AdicionarProfessor
{
    public class AdicionarProfessorResponse
    {
        public string Cpf { get; }
        public string Nome { get; }
        public string Mensagem { get; }

        public AdicionarProfessorResponse(string cpf, string nome, string mensagem)
        {
            Cpf=cpf;
            Nome=nome;
            Mensagem=mensagem;
        }
    }
}
