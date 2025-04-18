using Laboratory.Web.Service;
using Laboratory.Web.Service.IService;
using Laboratory.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient<IPatientService, PatientService>();
builder.Services.AddHttpClient<ITestService, TestService>();
builder.Services.AddHttpClient<ITestParameterService, TestParameterService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<ICartService, CartService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();
//builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


//SD.PatientAPIBase = builder.Configuration["ServiceUrls:PatientAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.TestAPIBase = builder.Configuration["ServiceUrls:TestAPI"];
SD.TestParameterAPIBase = builder.Configuration["ServiceUrls:TestParameterAPI"];
SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"];
SD.TestCartAPIBase = builder.Configuration["ServiceUrls:TestCartAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
//builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestParameterService, TestParameterService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

// Register ViewRenderHelper
builder.Services.AddScoped<ViewRenderHelper>();

// Register PdfService
builder.Services.AddScoped<PdfService>();

// Register DinkToPdf converter
//builder.Services.AddSingleton<IConverter, SynchronizedConverter>(sp =>
//{
//	return new SynchronizedConverter(new PdfTools());
//});

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for testion scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
