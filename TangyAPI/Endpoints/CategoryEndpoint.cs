using Carter;
using Microsoft.EntityFrameworkCore;
using TangyAPI.Data;
using TangyAPI.DTOs;
using TangyAPI.Models;

namespace TangyAPI.Endpoints
{
    public class CategoryEndpoint() : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/categories");

            group.MapGet("", GetCategoriesAsync)
                .WithName(nameof(GetCategoriesAsync));

            group.MapPost("", CreateCategoryAsync)
                .WithName(nameof(CreateCategoryAsync))
                .Accepts<CategoryDto>("application/json")
                .Produces<Category>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);

            group.MapGet("{id}", GetCategoriesByIdAsync);

            group.MapDelete("{id}", DeleteCategoryAsync);
        }

        public async Task<IResult> GetCategoriesAsync(ApplicationDbContext dbContext)
        {
            var allCategories = await dbContext.Categories.ToListAsync();
            return Results.Ok(allCategories);
        }

        public async Task<IResult> GetCategoriesByIdAsync(ApplicationDbContext dbContext, int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
                return Results.NotFound();
            return Results.Ok(category);
        }

        public async Task<IResult> CreateCategoryAsync(CategoryDto category, ApplicationDbContext dbContext)
        {
            var count = await dbContext.Categories.CountAsync();
            var categoryObj = new Category { Id = count + 1, Name = category.Name, AddedOn = DateTime.UtcNow };
            _ = await dbContext.Categories.AddAsync(categoryObj);
            _ = await dbContext.SaveChangesAsync();
            return Results.Created($"api/categories/{categoryObj.Id}", categoryObj);
        }

        public async Task<IResult> DeleteCategoryAsync(int id, ApplicationDbContext dbContext)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
                return Results.NotFound();
            dbContext.Categories.Remove(category);
            _ = await dbContext.SaveChangesAsync();
            return Results.Accepted();
        }
    }
}
