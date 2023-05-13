using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public ProdutoRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<ProdutoModel>> AllProducts()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> GetById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ProdutoModel> Create(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }
        public async Task<ProdutoModel> Update(ProdutoModel produto, int id)
        {
            ProdutoModel produtoById = await GetById(id);
            if (produtoById == null)
            {
                throw new Exception($"Produto para ID: {id} não encontrado!");
            }

            produtoById.nomeproduto = produto.nomeproduto;
            produtoById.preco = produto.preco;
            produtoById.codigo = produto.codigo;
            produtoById.quant_estoque = produto.quant_estoque;

            _dbContext.Produtos.Update(produtoById);
            await _dbContext.SaveChangesAsync();

            return produtoById;
        }

        public async Task<bool> Delete(int id)
        {
            ProdutoModel produtoById = await GetById(id);
            if (produtoById == null)
            {
                throw new Exception($"Produto para ID: {id} não encontrado!");
            }

            _dbContext.Produtos.Remove(produtoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
