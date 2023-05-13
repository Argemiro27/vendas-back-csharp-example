using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> AllProducts();
        Task<ProdutoModel> GetById(int id);
        Task<ProdutoModel> Create(ProdutoModel produto);
        Task<ProdutoModel> Update(ProdutoModel produto, int id);
        Task<bool> Delete(int id);
    }
}
