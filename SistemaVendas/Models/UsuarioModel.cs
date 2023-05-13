using SistemaVendas.Enums;

namespace SistemaVendas.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string? nomeusuario { get; set; }
        public string? email { get; set; }

        public string? password { get; set; }
        public RoleUsuario role { get; set; }
    }
}
