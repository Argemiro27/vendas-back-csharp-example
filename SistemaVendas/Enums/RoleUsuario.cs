using System.ComponentModel;

namespace SistemaVendas.Enums
{
    public enum RoleUsuario
    {
        [Description("Administrador")]
        Adm = 1, 
        [Description("Funcionário")]  
        Funcionario = 2,
    }
}
