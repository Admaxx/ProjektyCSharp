using CEIDGASPNetCore.Controllers;
using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using CEIDGREGON;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContainerResolve, ContrainerResolve>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "CEIDG",
            pattern: "{controller=CEIDG}/{action=Index}",
            defaults: new { controller = "CEIDG" }
        );

app.Run();
