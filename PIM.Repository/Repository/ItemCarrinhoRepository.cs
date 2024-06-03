using Microsoft.EntityFrameworkCore;
using PIM.Models;

namespace PIM.Repository.Repository
{
    public class ItemCarrinhoRepository(PIMDbContext context) : IRepository<ItemCarrinho>
    {
        protected readonly PIMDbContext _context = context;

        public void Adicionar(ItemCarrinho entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(ItemCarrinho entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(ItemCarrinho entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public ItemCarrinho ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemCarrinho> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
