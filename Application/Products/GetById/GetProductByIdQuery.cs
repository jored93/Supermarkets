using Products.Common;

namespace Application.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<ProductResponse>>;

