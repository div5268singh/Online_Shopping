using Online_Shopping_Web_Service.IService;
using Online_Shopping_Web_Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();

builder.Services.AddScoped<ICategoryWebService, CategoryWebService>();
builder.Services.AddScoped<ICustomerWebService, CustomerWebService>();
builder.Services.AddScoped<ILoginWebService, LoginWebService>();
builder.Services.AddScoped<IProductWebService, ProductWebService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
