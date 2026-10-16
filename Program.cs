using Ferocity.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Ferocity.Data;
using Ferocity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
////////////////////////////
//Configurar DbContext con SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<FerocityDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(5, 6, 26))

    ));



builder.Services.AddScoped<UsuarioService>();
/*builder.Services.AddScoped<VacantesServices>();

builder.Services.AddSingleton<ParametrosService>();*/


///////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
