using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Components;
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Service;

var builder = WebApplication.CreateBuilder(args);

// Se agregan los servicios 
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<VentaService>();

var app = builder.Build();

// Se configura el HTTP 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
