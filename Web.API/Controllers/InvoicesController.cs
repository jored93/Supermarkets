using Application.Invoices.Create;
using Application.Invoices.GetById;
using Application.Invoices.GetAll;


namespace Web.API.Controllers;

[Route("invoices")]
public class Invoices : ApiController
{
    private readonly ISender _mediator;

    public Invoices(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // Invoice-related endpoints

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoicesResult = await _mediator.Send(new GetAllInvoicesQuery());

        return invoicesResult.Match(
            invoices => Ok(invoices),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoiceById(Guid id)
    {
        var invoiceResult = await _mediator.Send(new GetInvoiceByIdQuery(id));

        return invoiceResult.Match(
            invoice => Ok(invoice),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            invoiceId => Ok(invoiceId),
            errors => Problem(errors)
        );
    }
}

