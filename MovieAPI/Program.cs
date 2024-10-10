    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;

    var builder = WebApplication.CreateBuilder(args);

    // Configure database connection
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Add CORS to allow your Angular frontend to access the API
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

    // Register controllers
    builder.Services.AddControllers();

    // Register OpenAPI/Swagger services if necessary
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });

    
    var app = builder.Build();

    // Enable CORS for all requests
    app.UseCors("AllowAllOrigins");
    app.UseStaticFiles();

    // Configure the HTTP request pipeline for development environment
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }

    app.UseHttpsRedirection();

    // Set up API endpoints
    app.MapControllers();

    app.UseCors("AllowAllOrigins");
    app.Run();
