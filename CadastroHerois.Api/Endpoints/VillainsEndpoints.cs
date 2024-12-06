using CadastroHerois.Api.Inputs;
using CadastroHerois.Api.Inputs.Villains;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.UseCases.Villains;
using Microsoft.AspNetCore.Mvc;

namespace CadastroHerois.Api.Endpoints;

public static class VillainsEndpoints
{
    public static void MapVillainsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("villains");
        
        group.MapPost("/", async (ICreateVillain createVillain, CreateVillainInput input) =>
            {
                var insertId = await createVillain.ExecuteAsync(input);
                
                return Results.Created($"/villain/{insertId}", insertId);
            })
            .WithName("CreateNewVillainAsync")
            .WithOpenApi();
        
        group.MapPut("/{id:int}", async ([FromServices] IUpdateVillain updateVillain, int id, [FromBody] UpdateVillainInput input) =>
            {
                input.SetId(id);
                
                var updatedHero = await updateVillain.ExecuteAsync(input);

                return Results.Ok(updatedHero);
            })
            .WithName("UpdateVillainAsync")
            .WithOpenApi();
        
        
        group.MapGet("/{id:int}", async ([FromServices] IGetVillainById getVillainById, [FromRoute] int id) =>
            {
                var input = new GetVillainByIdInput(id);
                var hero = await getVillainById.ExecuteAsync(input);

                return Results.Ok(hero);
            })
            .WithName("GetVillainByIdAsync")
            .WithOpenApi();
        
        group.MapGet("/", async ([FromServices] IGetAllVillains getAllVillains) =>
            {
                var villains = await getAllVillains.ExecuteAsync(default);

                return Results.Ok(villains);
            })
            .WithName("GetAllVillainsAsync")
            .WithOpenApi();
    }
}