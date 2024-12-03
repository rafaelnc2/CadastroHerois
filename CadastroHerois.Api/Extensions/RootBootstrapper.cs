using System.Data;
using System.Data.SqlClient;
using CadastroHerois.Api.Entities;
using CadastroHerois.Api.Infra.Repositories;
using CadastroHerois.Api.Interfaces;
using CadastroHerois.Api.Interfaces.Repositories;
using CadastroHerois.Api.UseCases.Heroes;
using CadastroHerois.Api.UseCases.Vilains;

namespace CadastroHerois.Api.Extensions;

public static class RootBootstrapper
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add context
        services.AddScoped<IDbConnection>(db =>
            new SqlConnection(configuration.GetConnectionString("SqlServer")));
        
        // Add Repositories
        services.AddScoped<IHeroRepository, HeroRepository>();
        services.AddScoped<IVillainRepository, VillainRepository>();
        
        // Add UseCases
        services.AddScoped<ICreateHero, CreateHero>();
        services.AddScoped<IGetHeroById, GetHeroById>();
        services.AddScoped<IGetAllHeroes, GetAllHeroes>();
        services.AddScoped<IUpdateHero, UpdateHero>();

        services.AddScoped<ICreateVillain, CreateVillain>();
        services.AddScoped<IGetVillainById, GetVillainById>();
        services.AddScoped<IGetAllVillains, GetAllVillains>();
        services.AddScoped<IUpdateVillain, UpdateVillain>();
        
        return services;
    }
}