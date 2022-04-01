using AutoMapper;
using LogicHandler.Handler.CategoryHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuocThangShopOnline.Admin.ViewModel;

namespace QuocThangShopOnline.Area.Client
{
    public class ClientCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClientCategoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index() => View(_mapper.Map<List<CategoryViewModel>>(_mediator.Send(new GetAllCategoryRequest { }).Result));


        [HttpGet]
        public IActionResult GetById(int id) => View(_mapper.Map<CategoryViewModel>(_mediator.Send(new GetCategoryByIdRequest { Id = id }).Result));

    }
}
