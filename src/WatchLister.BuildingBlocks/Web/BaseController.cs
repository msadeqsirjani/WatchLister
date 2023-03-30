namespace WatchLister.BuildingBlocks.Web;

[ApiController]
public class BaseController : Controller
{
    protected const string BaseApiPath = "api/v{version:apiVersion}";

    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}