//using ProductWebApi1.Model;

//namespace ProductWebApi1
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);
//            builder.Services.AddScoped<IProductService, ProductService>();
//            builder.Services.AddDbContext<MyDBContext>();
//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
//---------------------------Get only works----------------
//using ProductWebApi1.Model;

//namespace ProductWebApi1
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container
//            builder.Services.AddScoped<IProductService, ProductService>();
//            builder.Services.AddDbContext<MyDBContext>();

//            // Add CORS policy configuration
//            builder.Services.AddCors(options =>
//            {
//                options.AddPolicy("AllowReactApp", policy =>
//                {
//                    policy.WithOrigins("http://localhost:5173")  // React app's URL
//                          .AllowAnyHeader()                    // Allow any headers
//                          .AllowAnyMethod();                    // Allow any HTTP methods (GET, POST, etc.)
//                });
//            });

//            // Add controllers
//            builder.Services.AddControllers();

//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Enable Swagger in development environment
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            // Enable CORS globally for all controllers
//            app.UseCors("AllowReactApp");

//            app.UseAuthorization();

//            // Map controllers
//            app.MapControllers();

//            // Run the application
//            app.Run();
//        }
//    }
//}

//---------------------------------------------
using ProductWebApi1.Model;

namespace ProductWebApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddDbContext<MyDBContext>();

            // Add CORS policy configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")  // React app's URL
                          .AllowAnyHeader()                    // Allow any headers
                          .AllowAnyMethod();                   // Allow all HTTP methods (GET, POST, PUT, DELETE)
                });
            });

            // Add controllers
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Enable Swagger in development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable CORS globally for all controllers
            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            // Map controllers to handle HTTP GET, POST, PUT, DELETE endpoints
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
