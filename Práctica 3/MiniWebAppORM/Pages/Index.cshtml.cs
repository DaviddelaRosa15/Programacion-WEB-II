using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniWebAppORM.Data;
using MiniWebAppORM.Models;

namespace MiniWebAppORM.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Usuarios = _context.Usuarios.ToList();
    }

    public async Task<IActionResult> OnPostAsync(string nombre, string email)
    {
        var nuevoUsuario = new Usuario
        {
            Nombre = nombre,
            Email = email
        };

        _context.Usuarios.Add(nuevoUsuario);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
}