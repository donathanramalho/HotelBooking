using Application.Ports;
using Data;
using Microsoft.EntityFrameworkCore;
using Domain.Guests.Ports;
using Application.Guests;
using Data.Guests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


#region
builder.Services.AddScoped<IGuestManager, GuestManager>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();


#endregion

#region

var connectionString = builder.Configuration.GetConnectionString("Main");
builder.Services.AddDbContext<HotelDbContext>(
    options => options.UseSqlServer(connectionString));

#endregion

builder.Services.AddProblemDetails();

builder.Services.AddAutoMapper(typeof(GuestMapping));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // Mostra detalhes do erro no navegador
}
else
{
    app.UseExceptionHandler("/error"); // Para ambientes de produção
    app.UseHsts();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var errorFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (errorFeature != null)
        {
            var ex = errorFeature.Error;

            // Log detalhado
            Console.WriteLine($"Unhandled exception: {ex}");

            // Retorne uma resposta JSON com detalhes da exceção
            await context.Response.WriteAsJsonAsync(new
            {
                type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
                title = "An error occurred while processing your request.",
                status = 500,
                detail = ex.Message,
                traceId = context.TraceIdentifier // Inclua o traceId na resposta
            });
        }
    });
});

app.UseAuthorization();

app.MapControllers();



app.UseExceptionHandler();

app.Run();
