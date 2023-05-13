using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> AllUsers();
        Task<UsuarioModel> GetById(int id);
        Task<UsuarioModel> GetByEmail(string email);
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int id);
        Task<bool> Delete(int id);
    }
}
