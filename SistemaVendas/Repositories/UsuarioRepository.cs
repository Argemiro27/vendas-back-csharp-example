using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public UsuarioRepository(SistemaVendasDBContext sistemaVendasDBContext) { 
            _dbContext = sistemaVendasDBContext;
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<UsuarioModel> GetByEmail(string email)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.email == email);
        }

        public async Task<List<UsuarioModel>> AllUsers()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            usuario.password = BCrypt.Net.BCrypt.HashPassword(usuario.password);

            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<UsuarioModel> Update(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioById = await GetById(id);
            if (usuarioById == null)
            {
                throw new Exception($"Usuário para ID: {id} não encontrado!");
            }

            usuarioById.nomeusuario = usuario.nomeusuario;
            usuarioById.email = usuario.email;
            usuarioById.password = usuario.password;
            usuarioById.role = usuario.role;

            _dbContext.Usuarios.Update(usuarioById);
            await _dbContext.SaveChangesAsync();

            return usuarioById;
        }

        public async Task<bool> Delete(int id)
        {
            UsuarioModel usuarioById = await GetById(id);
            if (usuarioById == null)
            {
                throw new Exception($"Usuário para ID: {id} não encontrado!");
            }

            _dbContext.Usuarios.Remove(usuarioById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
