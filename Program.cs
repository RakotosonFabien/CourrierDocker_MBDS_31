using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CourrierDocker_MBDS_31.Data;
using CourrierDocker_MBDS_31.modeles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDbContext<CourrierDocker_MBDS_31Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourrierDocker_MBDS_31Context") ?? throw new InvalidOperationException("Connection string 'CourrierDocker_MBDS_31Context' not found.")));

var app = builder.Build();
//donnees par defauts
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
