using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.Handler.ProductHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuocThangShopOnline.Areas.Admin.Models;

namespace QuocThangShopOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index() => View(_mapper.Map<List<ProductViewModel>>(_mediator.Send(new GetAllProductRequest { }).Result));

        [HttpGet]
        public IActionResult GetProductById(int id) => View(_mapper.Map<ProductViewModel>(_mediator.Send(new GetProductByIdRequest { Id = id}).Result));

        [HttpGet]
        public IActionResult GetProductByCategoryId(int id) => View(_mapper.Map<List<ProductViewModel>>(_mediator.Send(new GetProductByCategoryIdRequest {CategoryId = id }).Result));

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public  IActionResult Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _mediator.Send(new CreateProductRequest { Product = _mapper.Map<ProductDTO>(model)});
            return RedirectToAction("Index", "Product", new { area = "admin" });
        }

        [HttpGet]
        public IActionResult Edit(int id)  => View(_mapper.Map<ProductViewModel>(_mediator.Send(new GetProductByIdRequest { Id = id }).Result));

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _mediator.Send(new UpdateProductRequest { Product = _mapper.Map<ProductDTO>(model) });
            return RedirectToAction("Index", "Product", new { area = "admin" });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _mediator?.Send(new DeleteProductRequest { Id = id });
            return RedirectToAction("Index", "Product", new { area = "admin" });
        }

    }
}
