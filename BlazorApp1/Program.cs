using BlazorApp1.Components;
using BlazorApp1;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

Batteries.Init();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();

// Configure EF Core to use SQLite with our connection string.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register our country service.
builder.Services.AddScoped<CountryService>();

var app = builder.Build();

// Apply migrations and seed data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Automatically apply pending migrations (code-first migration for this app).
    context.Database.Migrate();

    var countryService = services.GetRequiredService<CountryService>();
    await countryService.SeedCountriesAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

