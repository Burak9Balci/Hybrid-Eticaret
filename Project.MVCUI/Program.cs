using Project.BLL.ServiceInjections;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRepositoryService();
builder.Services.AddManagerServices();
builder.Services.AddDbContextService();
builder.Services.AddIdentityServiece();
builder.Services.AddHttpClient();
builder.Services.AddDistributedMemoryCache();

WebApplication app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
