using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repository.Repository;

namespace PIM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController(IRepository<Carrinho> repository) : ControllerBase
    {
        private readonly IRepository<Carrinho>? _repository = repository;

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(this._repository?.ObterTodos());
        }
    }
}
