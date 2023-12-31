
using HastaneGD.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

//JSON DOSYASINDA TANIMLADIĞIMIZ CONNECTİON STRİNGİ VERİTABANI BAĞLANTISININ YAPILABİLMESİ İÇİN BURADA KULLANIYORUZ.
builder.Services.AddDbContext<HContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("DataConnection"));
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//SAYFANIN BAŞLAYACAĞI ADRESİ SEÇİYORUZ.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
app.UseSession();
app.Run();
