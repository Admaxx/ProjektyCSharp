using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGREGON;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CeidgregonContext>().
    AddScoped<ContrainerResolve>().
    AddScoped<ConvertDocOnFormat>().
    AddScoped<ProgramGeneralData>();

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
