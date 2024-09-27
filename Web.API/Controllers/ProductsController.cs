using Application.Products.Create;
using Application.Products.GetById;
using Application.Products.Delete;
using Application.Products.GetAll;
using Application.Categories.Create;
using Application.Categories.GetById;
using Application.Categories.Delete;
using Application.Categories.GetAll;

namespace Web.API.Controllers;

[Route("products")]
public class Products : ApiController
{
    private readonly ISender _mediator;

    public Products(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // Product-related endpoints

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var productsResult = await _mediator.Send(new GetAllProductsQuery());

        return productsResult.Match(
            products => Ok(products),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var productResult = await _mediator.Send(new GetProductByIdQuery(id));

        return productResult.Match(
            product => Ok(product),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            productId => Ok(productId),
            errors => Problem(errors)
        );
    }

    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteProductCommand(id));

        return deleteResult.Match(
            productId => NoContent(),
            errors => Problem(errors)
        );
    }

    // Category-related endpoints

    [HttpGet("categories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categoriesResult = await _mediator.Send(new GetAllCategoriesQuery());

        return categoriesResult.Match(
            categories => Ok(categories),
            errors => Problem(errors)
        );
    }

    [HttpGet("categories/{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var categoryResult = await _mediator.Send(new GetCategoryByIdQuery(id));

        return categoryResult.Match(
            category => Ok(category),
            errors => Problem(errors)
        );
    }

    [HttpPost("categories")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            categoryId => Ok(categoryId),
            errors => Problem(errors)
        );
    }

    [HttpDelete("categories/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteCategoryCommand(id));

        return deleteResult.Match(
            categoryId => NoContent(),
            errors => Problem(errors)
        );
    }
}
