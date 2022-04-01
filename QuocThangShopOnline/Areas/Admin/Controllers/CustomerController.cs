using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuocThangShopOnline.Area.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CustomerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
