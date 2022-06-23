using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Warsztat.BLL.Services;
using Warsztat.BLL.Services.Interfaces;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories;
using Warsztat_v2.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IPartService, PartService>();

builder.Services.AddSwaggerGen();



// var conne = Configuration.GetConnectionString("DefaultConnection");

var conectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseSqlServer(conectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ServiceContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



CreateDbIfNotExists(app);//
ServiceContext context = new ServiceContext();
DbInitializer.Initialize(context);


app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        //try
        //{
        var context = services.GetRequiredService<ServiceContext>();
        DbInitializer.Initialize(context);
        //}
        //catch (Exception ex)
        //{
        //    var logger = services.GetRequiredService<ILogger<Program>>();
        //    logger.LogError(ex, "An error occurred creating the DB.");
        //}
    }
}