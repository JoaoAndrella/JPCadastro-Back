using JPCadastro.Operacional.Enumeradores;

namespace JPCadastro.Operacional.Commands.Curso.ListarCurso
{
    public class ListarCursoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Periodo Periodo { get; set; }
        public Guid? ProfessorId { get; set; }
        public string? PorfessorNome { get; set; }
    }
}
