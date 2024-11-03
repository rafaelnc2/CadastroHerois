using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.UseCases.Heroes;
using Microsoft.AspNetCore.Mvc;

namespace CadastroHerois.Api.Endpoints;

public static class HerosEndpoints
{
    public static void MapHerosEndpoints(this WebApplication app)
    {
        app.MapPost("/heros", async (ICreateHero createHero, CreateHeroInput input) =>
            {
                var insertId = await createHero.ExecuteAsync(input);
                
                return Results.Created($"/hero/{insertId}", insertId);
            })
        .WithName("CreateNewHeroAsync")
        .WithOpenApi();
        
        app.MapPut("/heros/{id:int}", async (
                [FromServices] IUpdateHero updateHero, 
                int id, 
                [FromBody] UpdateHeroInput input) =>
            {
                var updatedHero = await updateHero.ExecuteAsync(id, input);

                return Results.Ok(updatedHero);
            })
            .WithName("UpdateHeroAsync")
            .WithOpenApi();
        
        
        app.MapGet("/heros/{id:int}", async ([FromServices] IGetHeroById getHeroById, [FromRoute] int id) =>
            {
                var input = new GetHeroByIdInput(id);
                var hero = await getHeroById.ExecuteAsync(input);

                return Results.Ok(hero);
            })
        .WithName("GetHeroByIdAsync")
        .WithOpenApi();
        
        app.MapGet("/heros", async ([FromServices] IGetAllHeroes getAllHeroes) =>
            {
                var heros = await getAllHeroes.ExecuteAsync();

                return Results.Ok(heros);
            })
            .WithName("GetAllHeroesAsync")
            .WithOpenApi();
    }
}