using MediatR;
using Domain.Categories;
using Domain.Primitives;

namespace Application.Categories.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Guid>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Guid>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = new Category(
            new CategoryId(Guid.NewGuid()),
            command.Name,
            command.Description
        );

        _categoryRepository.Add(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category.Id.Value;
    }
}

