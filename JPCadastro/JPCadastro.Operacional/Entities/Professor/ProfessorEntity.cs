using JPCadastro.Core.Entities;
using JPCadastro.Operacional.Entities.Curso;

namespace JPCadastro.Operacional.Entities.Professor
{
    public class ProfessorEntity : EntityBase<string>
    {
       // public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }

        //CONSTRUTOR EF
        protected ProfessorEntity() { }

        public ProfessorEntity(string id, string nome, string telefone)
        {
            Id=id;
            //Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
        }
        public void Atualizar(string nome, string telefone)
        {
            Nome=nome;
            Telefone=telefone;
            this.AdicionarAtualizarProfessorContract();
        }
    }
}
