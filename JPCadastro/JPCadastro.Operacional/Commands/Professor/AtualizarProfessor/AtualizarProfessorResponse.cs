namespace JPCadastro.Operacional.Commands.Professor.AtualizarProfessor
{
    public class AtualizarProfessorResponse
    {
        public string Cpf { get; }
        public string Nome { get; }
        public string Mensagem { get; }
        
        public AtualizarProfessorResponse(string cpf, string nome, string mensagem)
        {
            Cpf=cpf;
            Nome=nome;
            Mensagem=mensagem;
        }


    }
}
