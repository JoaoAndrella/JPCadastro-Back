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

        TEntity ObterPorId(TId id);
        TEntity ObterPorSemRastreamento(TId id);
        IEnumerable<TEntity> ListarSemRastreamento();
        bool Existe(Func<TEntity, bool> onde);
        bool Existe(Func<TEntity, bool> onde, params Expression<Func<TEntity, object>>[] incluirPropriedadesNavegacao);
        bool Existe(Func<TEntity, bool> onde, params string[] incluirPropriedadesNavegacao);
    }
}
