using AutoMapper;
using LogicHandler.Handler.CategoryHandler.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuocThangShopOnline.Models;

namespace QuocThangShopOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public IActionResult Index() => View(_mapper.Map<List<CategoryViewModel>>(_mediator.Send(new GetAllCategoryRequest { }).Result));
    }
}
