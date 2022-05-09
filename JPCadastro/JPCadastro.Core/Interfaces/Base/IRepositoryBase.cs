using JPCadastro.Core.Entities;

namespace JPCadastro.Core.Interfaces.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        IEnumerable<TEntity> Listar();

        void Adcionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);

        TEntity ObterPorId(TId id);
    }
}
