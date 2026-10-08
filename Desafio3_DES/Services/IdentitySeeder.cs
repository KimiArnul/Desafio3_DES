using Desafio3_DES.Models;
using Microsoft.AspNetCore.Identity;

namespace Desafio3_DES.Services
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<Usuario>>();

            foreach (var rol in new[] { Roles.Administrador, Roles.Usuario })
                if (!await roleManager.RoleExistsAsync(rol))
                    await roleManager.CreateAsync(new IdentityRole(rol));

            const string email = "admin@recetas.com";
            var admin = await userManager.FindByEmailAsync(email);
            if (admin is null)
            {
                admin = new Usuario { UserName = email, Email = email, EmailConfirmed = true };
                await userManager.CreateAsync(admin, "Admin123!");
            }
            if (!await userManager.IsInRoleAsync(admin, Roles.Administrador))
                await userManager.AddToRoleAsync(admin, Roles.Administrador);
        }
    }
}
