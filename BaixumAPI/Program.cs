using BaixumAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BaixumDb>(opt => opt.UseInMemoryDatabase("BaixumAPI"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/usuarios", async (BaixumDb db) =>
    await db.Usuarios.ToListAsync());

app.MapGet("/usuarios/admin", async (BaixumDb db) =>
    await db.Usuarios.Where(t => t.IsAdmin).ToListAsync());

app.MapGet("/usuarios/{id}", async (int id, BaixumDb db) =>
    await db.Usuarios.FindAsync(id)
        is Usuario usuario
            ? Results.Ok(usuario)
            : Results.NotFound());

app.MapPost("/usuarios/", async (Usuario usuario, BaixumDb db) =>
{
    db.Usuarios.Add(usuario);
    await db.SaveChangesAsync();

    return Results.Created($"/usuarios/{usuario.Id}", usuario);
});

app.MapPut("/usuarios/{id}", async (int id, Usuario inputUsuario, BaixumDb db) =>
{
    var todo = await db.Usuarios.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputUsuario.Name;
    todo.IsAdmin = inputUsuario.IsAdmin;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/usuarios/{id}", async (int id, BaixumDb db) =>
{
    if (await db.Usuarios.FindAsync(id) is Usuario usuario)
    {
        db.Usuarios.Remove(usuario);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();