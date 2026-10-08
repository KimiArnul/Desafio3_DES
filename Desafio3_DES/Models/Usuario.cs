using Microsoft.AspNetCore.Identity;


namespace Desafio3_DES.Models
{
    public class Usuario : IdentityUser { }

    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string Usuario = "Usuario";
    }
}