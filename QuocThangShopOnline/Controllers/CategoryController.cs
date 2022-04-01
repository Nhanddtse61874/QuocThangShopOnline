using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.Handler.CategoryHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuocThangShopOnline.Models;

namespace QuocThangShopOnline.Admin.Controllers
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
        public IActionResult Index() => View( _mapper.Map<List<ClientCategoryViewModel>>(_mediator.Send(new GetAllCategoryRequest { }).Result));


        [HttpGet]
        public  IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ClientCategoryViewModel model)
        {
            _mediator.Send(new AddCategoryRequest { CategoryDTO = _mapper.Map<CategoryDTO>(model)});
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(_mapper.Map<ClientCategoryViewModel>(_mediator.Send(new GetCategoryByIdRequest { Id = id}).Result));

        [HttpPost]
        public async Task<IActionResult> Edit(ClientCategoryViewModel model)
        {
           await _mediator.Send(new UpdateCategoryRequest { CategoryDTO = _mapper.Map<CategoryDTO>(model)});
           return Redirect("Index");
        }
    }
}
