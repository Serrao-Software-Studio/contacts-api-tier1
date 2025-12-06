using _T1__ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------
//  1. SERVICES: Add services to the container
// ------------------------------------------

// Tier 1 Persistence: EF Core In-Memory provider (for simple local/dev storage)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("ContactsDb");
});

// Controllers for standard MVC/API architecture    
builder.Services.AddControllers();

// Tier 1 Documentation: Minimal Swagger/OpenAPI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ------------------------------------------
//  2. DATABASE: Bootstrap and Initialization
// ------------------------------------------

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Tier 1 MVP: EnsureCreated bypasses complex migrations
    db.Database.EnsureCreated();
}

// ------------------------------------------
//  3. PIPELINE: Configure the HTTP request pipeline
// ------------------------------------------

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();