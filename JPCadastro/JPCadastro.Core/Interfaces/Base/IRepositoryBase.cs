using JPCadastro.Core.Entities;
using System.Linq.Expressions;

namespace JPCadastro.Core.Interfaces.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        IEnumerable<TEntity> Listar();

        void Adcionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);

        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde);
        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        TEntity ObterPorSemRastreamento(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);
    }
}
