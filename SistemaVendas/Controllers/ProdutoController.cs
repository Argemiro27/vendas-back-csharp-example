using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> AllProducts()
        {
            List<ProdutoModel> produtos = await _produtoRepository.AllProducts();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoModel>>> GetById(int id)
        {
            ProdutoModel produtos = await _produtoRepository.GetById(id);
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Create([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepository.Create(produtoModel);
            return Ok(produto);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ProdutoModel>> Update([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.id = id;
            ProdutoModel produto = await _produtoRepository.Update(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ProdutoModel>> Delete(int id)
        {
            bool deleted = await _produtoRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
