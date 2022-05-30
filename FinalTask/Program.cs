using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalTask.Areas.Identity.Data;
using FinalTask.Repositories;
using FinalTask.Services;
using FinalTask.Model;
using FinalTask.Pages.Notes;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<NotesRepository>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<FinalTaskContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinalTaskContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FinalTaskUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FinalTaskContext>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
