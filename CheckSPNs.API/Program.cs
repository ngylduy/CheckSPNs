using Alachisoft.NCache.Caching.Distributed;
using CheckSPNs.Domain.Models.MongoDb.CheckExamScore;
using CheckSPNs.Infrastructure.Configuration;
using CheckSPNs.Infrastructure.MiddleWare;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Serilog;

namespace CheckSPNs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            var CORS = "_cors";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORS,
                                  policy =>
                                  {
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyOrigin();
                                  });
            });

            //NCache
            builder.Services.AddNCacheDistributedCache(configuration =>
            {
                configuration.CacheName = "CheckSPNsCache";
                configuration.EnableLogs = true;
                configuration.ExceptionsEnabled = true;
            });

            //Register the Core Dependencies
            builder.Services.AddCoreDependencies();

            //Register the database context
            builder.Services.RegisterContextDb(builder.Configuration);

            //Register the MongoDB
            builder.RegisterMongoDb();

            //Resgister the Dependency Injection
            builder.Services.RegisterDI();

            // Register Authentication Token
            builder.Services.RegisterTokenBear(builder.Configuration);

            //Serilog
            Log.Logger = new LoggerConfiguration()
                          .ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Services.AddSerilog();

            builder.WebHost.ConfigureKestrel(options => options.Limits.MaxRequestBodySize = 50 * 1024 * 1024);

            //Odata config
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<ExamScore>("ExamScoreOData");

            builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100)
            .AddRouteComponents("odata", model: modelBuilder.GetEdmModel()));



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            //app.UseHttpsRedirection();
            app.UseCors(CORS);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
