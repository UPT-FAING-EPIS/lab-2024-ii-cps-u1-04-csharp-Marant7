var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ejemplo de un endpoint simple
app.MapGet("/api/bank", () =>
{
    return Results.Ok(new { Message = "Bienvenido a la API del banco" });
})
.WithName("GetBankInfo")
.WithOpenApi();

app.Run();