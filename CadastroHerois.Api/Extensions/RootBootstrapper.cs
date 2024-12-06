using System.Data.SqlClient;
using CadastroHerois.Api.Interfaces.UseCases.Heroes;
using CadastroHerois.Api.Interfaces.UseCases.Villains;
using CadastroHerois.Api.UseCases.Heroes;
using CadastroHerois.Api.UseCases.Villains;

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