using System.Runtime.CompilerServices;
using DealerX.Components;
using DealerX.Data.Context;
using DealerX.Services.Vehicle;
using DealerX.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();
ConfigureServices(builder.Services);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();

 static void ConfigureServices(IServiceCollection service){
	service.AddDbContext<IdbContext, dbContext>();
	service.AddScoped<IVehicleService, VehicleService>();
	service.AddScoped<IModelService, ModelService>();
	service.AddScoped<IStaticDataService, StaticDataService>();

}