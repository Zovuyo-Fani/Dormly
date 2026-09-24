using DORMLY.Components;
using Dormly.Data;
using Dormly.Shared.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DORMLY.Client._Imports).Assembly);


 app.MapGet("/api/listings", async (AppDbContext dbContext) =>
 await dbContext.Listings.ToListAsync());


 app.MapPost("/api/register", async (User newUser, AppDbContext dbContext) =>
 {
     newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);
     dbContext.Users.Add(newUser);
     await dbContext.SaveChangesAsync();
     return Results.Ok(new { newUser.id, newUser.Name, newUser.email, newUser.Role, });
 });

app.MapPost("/api/login", async (LoginRequest login, AppDbContext dbContext) =>
{
    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.email == login.email);
    if (user == null || !BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
    {
        return Results.Unauthorized();
    }
    return Results.Ok(new { user.id, user.Name, user.email, user.Role });
});

  app.Run();




















  record LoginRequest(string email, string PasswordHash);

