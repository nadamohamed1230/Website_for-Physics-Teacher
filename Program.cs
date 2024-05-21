<<<<<<< HEAD
using DBproject.Pages;
using DBproject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
=======
using DBproject.models;
>>>>>>> 688e420e94ccdbe4733a190d02bf0171a14037bb

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
<<<<<<< HEAD
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<DB>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout= TimeSpan.FromMinutes(30);
});
=======
builder.Services.AddSingleton<DB>();

>>>>>>> 688e420e94ccdbe4733a190d02bf0171a14037bb
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


app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
