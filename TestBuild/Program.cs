var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "totalChats",
    pattern: "Project/TotalChats",
        defaults: new { controller = "Project", action = "TotalChats" });
app.MapControllerRoute(
    name: "duration",
    pattern: "Project/Duration",
        defaults: new { controller = "Project", action = "Duration" });
app.MapControllerRoute(
    name: "rating",
    pattern: "Project/Ratings",
        defaults: new { controller = "Project", action = "Ratings" });
app.MapControllerRoute(
    name: "responseTime",
    pattern: "Project/ResponseTime",
        defaults: new { controller = "Project", action = "ResponseTime" });
app.MapControllerRoute(
    name: "tags",
    pattern: "Project/Tags",
        defaults: new { controller = "Project", action = "Tags" });

app.Run();
