using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.UseCases.Heroes;
using Microsoft.AspNetCore.Mvc;

namespace CadastroHerois.Api.Endpoints;

public static class HeroesEndpoints
{
    public static void MapHerosEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("heroes");
        
        group.MapPost("/", async (ICreateHero createHero, CreateHeroInput input) =>
            {
                var insertId = await createHero.ExecuteAsync(input);
                
                return Results.Created($"/hero/{insertId}", insertId);
            })
        .WithName("CreateNewHeroAsync")
        .WithOpenApi();
        
        group.MapPut("/{id:int}", async ([FromServices] IUpdateHero updateHero, int id, 
                [FromBody] UpdateHeroInput input) =>
            {
                var updatedHero = await updateHero.ExecuteAsync(id, input);

                return Results.Ok(updatedHero);
            })
            .WithName("UpdateHeroAsync")
            .WithOpenApi();
        
        
        group.MapGet("/{id:int}", async ([FromServices] IGetHeroById getHeroById, [FromRoute] int id) =>
            {
                var input = new GetHeroByIdInput(id);
                var hero = await getHeroById.ExecuteAsync(input);

                return Results.Ok(hero);
            })
        .WithName("GetHeroByIdAsync")
        .WithOpenApi();
        
        group.MapGet("/", async ([FromServices] IGetAllHeroes getAllHeroes) =>
            {
                var heroes = await getAllHeroes.ExecuteAsync();

                return Results.Ok(heroes);
            })
            .WithName("GetAllHeroesAsync")
            .WithOpenApi();
    }
}