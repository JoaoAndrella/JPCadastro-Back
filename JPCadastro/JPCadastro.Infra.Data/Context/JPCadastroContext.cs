using JPCadastro.Operacional.Entities.Aluno;
using JPCadastro.Operacional.Entities.Curso;
using JPCadastro.Operacional.Entities.Professor;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace JPCadastro.Infra.Data.Context
{
    public class JPCadastroContext : DbContext
    {
        public JPCadastroContext()
        {
        }

        public JPCadastroContext(DbContextOptions<JPCadastroContext> options) : base(options)
        {
        }

        public DbSet<AlunoEntity> AlunoSet { get; set; }
        public DbSet<ProfessorEntity> ProfessorSet { get; set; }
        public DbSet<CursoEntity> CursoSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setar o comportamento do Delete em tabelas com relacionamentos
            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JPCadastroContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=mysql.ispac.com.br;port=3306;database=ispac24;uid=ispac24;password=ispac123";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
