using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Components;
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Service;

var builder = WebApplication.CreateBuilder(args);

// Servicios Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servicios
builder.Services.AddScoped<VentaService>();
builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<MarcaService>();
builder.Services.AddScoped<VehiculoService>();

// Controllers API
builder.Services.AddControllers();

var app = builder.Build();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Configuración HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

// Mapear controllers primero
app.MapControllers();

// Mapear Blazor solo una vez
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();