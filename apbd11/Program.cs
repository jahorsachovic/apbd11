using apbd11.DAL;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        builder.Services.AddOpenApi();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.MapControllers();
        
        app.Run();
    }
}