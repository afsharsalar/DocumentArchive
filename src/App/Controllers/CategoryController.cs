using DocumentArchive.Application.Categories.GetCategories;

namespace App.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IMediator _mediator ;
		private readonly IMapper _mapper;

		public CategoryController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}


		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetCategoriesQuery { Page=1, PageSize=20}, cancellationToken);
			var model= _mapper.Map<IEnumerable<GetCategoriesResponse>>(result);
			return View(model);
		}
	}
}
