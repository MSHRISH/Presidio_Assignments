using Microsoft.EntityFrameworkCore;
using PizzaApi.Contexts;
using PizzaApi.Interfaces;
using PizzaApi.Models;
using PizzaApi.Repositories;
using PizzaApi.Services;

namespace PizzaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context
            builder.Services.AddDbContext<PizzaAPIContext>(
                    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Authentication>, UserAuthRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IUserAuthServices,UserAuthServices>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
