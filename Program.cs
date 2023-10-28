using Login_repository_pattern;
using Login_repository_pattern.Models.Employee;
using Login_repository_pattern.Models.Time;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services); // calling ConfigureServices method

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbContext")));
builder.Services.AddDbContext<TimesheetDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TimesheetDbContext")));


var app = builder.Build();
//startup.Configure(app, builder.Environment); // calling Configure method


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();

