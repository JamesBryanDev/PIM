namespace PIM.Repository.Repository
{
    public interface IRepository<TEntity>
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity ObterPorId(int id);
        List<TEntity> ObterTodos();
    }
}
