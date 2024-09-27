using Domain.Categories;
using Domain.Primitives;

namespace Application.Categories.Delete;

internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Unit>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        if (await _categoryRepository.GetByIdAsync(new CategoryId(command.Id)) is not Category category)
        {
            return Error.NotFound("Category.NotFound", "The category with the provided Id was not found.");
        }

        _categoryRepository.Delete(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

