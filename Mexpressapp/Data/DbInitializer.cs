using Microsoft.AspNetCore.Identity;

namespace Mexpressapp.Data
{
    // Roles são perfils de usuário pré-definidos que ajudam a gerenciar permissões e acessos dentro de uma aplicação.
    public static class DbInitializer // Cria a classe estática DbInitializer
    {
        // Cria o método público estático SeedRolesAsync que recebe um IServiceProvider como parâmetro para permitir a injeção de dependência.
        public static async Task SeedRolesAsyns(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // Obtém o RoleManager do provedor de serviços.

            string [] roleNames = { "Admin", "User" }; // Define os nomes dos papéis que serão criados.

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role)) // Verifica se o papel já existe.
                {
                    await roleManager.CreateAsync(new IdentityRole(role)); // Cria o papel se ele não existir.
                }
            }
        }
    }
}
