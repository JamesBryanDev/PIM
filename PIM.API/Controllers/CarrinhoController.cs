using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Models.DTO;
using PIM.Repository.Repository;

namespace PIM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController(IRepository<Carrinho> repository, IRepository<ItemCarrinho> itemCarrinhorepository) : ControllerBase
    {
        private readonly IRepository<Carrinho>? _repository = repository;
        private readonly IRepository<ItemCarrinho>? _itemCarrinhorepository = itemCarrinhorepository;

        [HttpPost("Criar")]
        public IActionResult Criar([FromBody] CreateCarrinhoDTO carrinhoDTO)
        {
            Carrinho carrinho = new()
            {
                clienteId = carrinhoDTO.clienteId,
                dataPedido = carrinhoDTO.dataPedido,
                statusPedido = carrinhoDTO.statusPedido,
            };

            if (carrinhoDTO is null)
                throw new ArgumentNullException(nameof(carrinhoDTO));
            else
            {
                this._repository?.Adicionar(carrinho);
                var valorTotal = 0.0m;
                foreach (var item in carrinhoDTO.itens)
                {
                    ItemCarrinho itemCarrinho = new()
                    {
                        carrinhoId = carrinho.id,
                        produtoId = item.produtoId,
                        quantidade = item.quantidade,
                        total = item.total
                    };
                    if (itemCarrinho is not null)
                    {
                        this._itemCarrinhorepository?.Adicionar(itemCarrinho);
                        valorTotal += itemCarrinho.total;
                    }
                    else
                        throw new ArgumentNullException(nameof(itemCarrinho));
                }
                carrinho.valorTotal = valorTotal;
                this._repository?.Atualizar(carrinho);
            }
            return Ok();
        }

        [HttpGet("Obtertodos")]
        public IActionResult ObterTodos()
        {
            return Ok(this._repository?.ObterTodos());
        }

        [HttpGet("Obterporid/{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok(this._repository?.ObterPorId(id));
        }

        [HttpPut("Alterar/{id}")]
        public IActionResult Alterar(int id)
        {
            var carrinho = this._repository?.ObterPorId(id);
            this._repository?.Atualizar(carrinho!);
            return Ok();
        }

        [HttpDelete("Apagar/{id}")]
        public IActionResult Apagar(int id)
        {
            var carrinho = this._repository?.ObterPorId(id);
            this._repository?.Excluir(carrinho!);
            return Ok();
        }
    }
}
