using Products.Common;
using Domain.Products;

namespace Application.Products.GetById;

internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<ErrorOr<ProductResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _productRepository.GetByIdAsync(new ProductId(query.Id)) is not Product product)
        {
            return Error.NotFound("Product.NotFound", "The product with the provided Id was not found.");
        }

        return new ProductResponse(
            product.Id.Value,
            product.Name,
            product.Description,
            product.Price,
            product.Stock,
            product.CategoryId.Value,
            product.IsActive);
    }
}

