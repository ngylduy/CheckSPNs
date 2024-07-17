using CheckSPNs.Client.Data;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Client.Data.Service.Implementation;

namespace CheckSPNs.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();

            ApiBase.APIBaseUrl = builder.Configuration["ServiceUrls:BaseUrlAPI"];

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute(
                        "/Privacy",
                        "/chinh-sach.html"
                    );
                    options.Conventions.AddAreaPageRoute(
                        areaName: "Product",
                        pageName: "/Detail",
                        route: "/sanpham/{nameproduct?}"
                    );
                }
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            builder.Services.AddHttpClient();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IStatService, StatService>();
            builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseStatusCodePages("text/html", "<h1>Error! Status Code {0}</h1>");
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}