using Mezzex.com.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Custom route for services without exposing the controller name
app.MapControllerRoute(
    name: "services",
    pattern: "website-designing-development",
    defaults: new { controller = "Services", action = "Website_designing_development" }
);
app.MapControllerRoute(
    name: "services",
    pattern: "digital-marketing",
    defaults: new { controller = "Services", action = "Digital_marketing" }
);

app.MapControllerRoute(
    name: "services",
    pattern: "software-development",
    defaults: new { controller = "Services", action = "Software_development" }
);

app.MapControllerRoute(
    name: "services",
    pattern: "app-development",
    defaults: new { controller = "Services", action = "App_development" }
);

app.MapControllerRoute(
    name: "services",
    pattern: "ecommerce-service",
    defaults: new { controller = "Services", action = "Ecommerce_service" }
);
app.MapControllerRoute(
    name: "services",
    pattern: "warehouse-management",
    defaults: new { controller = "Services", action = "Warehouse_management" }
);

// Default route for all other controllers and actions
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
