using JPCadastro.Core.Entities;
using JPCadastro.Operacional.Entities.Professor;
using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Entities.Curso
{
    public class CursoEntity : EntityBase<Guid>
    {
        public string Nome { get; private set; }
        public Periodo Periodo { get; private set; }
        //public string ProfessorId { get; private set; }
        public virtual ProfessorEntity Professor { get; private set; }

        public CursoEntity()
        {
        }

        public CursoEntity(string nome, Periodo periodoCurso)
        {
            Id=Guid.NewGuid();
            Nome=nome;
            Periodo=periodoCurso;
        }

        public void Atualizar(string nome, Periodo periodoCurso)
        {
            Nome=nome;
            Periodo=periodoCurso;
        }
    }
}
