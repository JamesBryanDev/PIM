using Microsoft.EntityFrameworkCore;
using PIM.Models;

namespace PIM.Repository.Repository
{
    public class CarrinhoRepository(PIMDbContext context) : IRepository<Carrinho>
    {
        protected readonly PIMDbContext _context = context;

        public void Adicionar(Carrinho entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(Carrinho entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Carrinho entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Carrinho ObterPorId(int id)
        {
            var obj = _context.carrinhos
                .AsNoTracking()
                .Where(x => x.id == id)
                .ToList();

            return obj.FirstOrDefault();
        }

        public List<Carrinho> ObterTodos()
        {
            return [.. _context.carrinhos];
        }
    }
}
