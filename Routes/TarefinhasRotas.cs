using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Tarefinhas.Data;
using Tarefinhas.Models;

namespace Tarefinhas.Routes;

public static class TarefinhasRotas
{
    public static void getTarefinhasRoutes(this WebApplication app)
    {
        //prefixo -- como no Laravel
        var route = app.MapGroup("v1/tarefinha");

        route.MapPost("", 
            async (TarefinhasRequest req, TarefinhasContext context) =>
            {
                var tarefinha = new TarefinhasModel(req.title, req.description);
                await context.Tarefinhas.AddAsync(tarefinha);
                //salvamos no banco de dados
                await context.SaveChangesAsync();
            });

        route.MapGet("", async (TarefinhasContext context) =>
        {
            var tarefinhas = await context.Tarefinhas.ToListAsync();
            return Results.Ok(tarefinhas);
        });
        
        route.MapPut("{id:guid}", 
            async (Guid id,TarefinhasRequest req, TarefinhasContext context) =>
            {
                //id
                var tarefinha = await context.Tarefinhas.
                    FirstOrDefaultAsync(x => x.Id == id);
                
                
                //verificar se esse id existe no banco
                
                 

                if (tarefinha.Title != req.title || tarefinha.Description != req.description)
                {
                    tarefinha.ChangeTitleorDescription(req.title, req.description);
                    await context.SaveChangesAsync();
                    
                }
                
                return Results.Ok("Tarefinha Atualizado!");
            });
        route.MapDelete("{id:guid}", 
            async(Guid id,TarefinhasContext context) =>
            {
                var tarefinha = await context.Tarefinhas.FirstAsync(x => x.Id == id);

                if (tarefinha != null)
                {
                    context.Tarefinhas.Remove(tarefinha);
                    await context.SaveChangesAsync();
                }
                
                return Results.NoContent();
            });
    }
}