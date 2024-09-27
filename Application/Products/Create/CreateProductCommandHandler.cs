using MediatR;
using Domain.Products;
using Domain.Primitives;
using Domain.Categories;
using Domain.DomainErrors;

namespace Application.Products.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Guid>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(
            new ProductId(Guid.NewGuid()),
            command.Name,
            command.Description,
            command.Price,
            new CategoryId(command.CategoryId),
            command.IsActive
        );

        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return product.Id.Value;
    }
}

