using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
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
            var keyVaultUrl = builder.Configuration["AzureKeyVault:VaultUrl"];
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            builder.Configuration.AddAzureKeyVault(client, new KeyVaultSecretManager());
            // Get the SQL connection string from Key Vault
            var connectionString = builder.Configuration["sqlconnectionstring"];
            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}