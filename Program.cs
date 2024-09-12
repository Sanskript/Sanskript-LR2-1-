var builder = WebApplication.CreateBuilder(args);

// Додаємо файли конфігурацій
builder.Configuration.AddJsonFile("companies.json", optional: false, reloadOnChange: true);
builder.Configuration.AddXmlFile("companies.xml", optional: false, reloadOnChange: true);
builder.Configuration.AddIniFile("companies.ini", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("myinfo.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CompanyAnalyzerService>(); // Реєструємо сервіс

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
