using Microsoft.EntityFrameworkCore;
using MusmulogullariMarket.Domain.Interfaces.Repositories;
using MusmulogullariMarket.Infrastructure.Persistence.Context;
using MusmulogullariMarket.Infrastructure.Persistence.Seed;
using MusmulogullariMarket.Infrastructure.Repositories;
using MusmulogullariMarket.Application.Interfaces.Services;
using MusmulogullariMarket.Application.Services;
using MusmulogullariMarket.Application.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Services
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgreSql")
    );
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<
            MusmulogullariMarket.Application.Validators.Categories.CreateCategoryDtoValidator>();
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataSeeder.Seed(context);
}

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
