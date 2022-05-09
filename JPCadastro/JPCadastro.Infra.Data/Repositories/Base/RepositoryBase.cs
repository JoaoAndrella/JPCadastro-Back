using JPCadastro.Core.Entities;
using JPCadastro.Core.Interfaces.Base;
using JPCadastro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JPCadastro.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : EntityBase<TId>
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly JPCadastroContext Context;

        public RepositoryBase(JPCadastroContext context)
        {
            DbSet=context.Set<TEntity>();
            Context=context;
        }

        public void Adcionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public IEnumerable<TEntity> Listar()
        {
           return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> ListarSemRastreamento()
        {
            return DbSet.AsNoTracking().AsEnumerable();
        }

        public TEntity ObterPorId(TId id)
        {
            return DbSet.Find(id);
        }

        public TEntity ObterPorSemRastreamento(TId id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => p.Id.Equals(id));
        }

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
