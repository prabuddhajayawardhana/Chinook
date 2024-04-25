using Chinook.Areas.Identity;
using Chinook.Configuration.Middlewares;
using Chinook.Core.Data;
using Chinook.Core.Uow;
using Chinook.Core.Data.Models;
using Chinook.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Chinook.Services.Auth;
using Serilog;
using Chinook.Utilities.Helper;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<ChinookContext>(opt => opt.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ChinookUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ChinookContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ChinookUser>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<IGlobalErrorService, GlobalErrorService>();

builder.Services.AddScoped<EventManager>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseExceptionHandlingMiddleware();

app.Run();
