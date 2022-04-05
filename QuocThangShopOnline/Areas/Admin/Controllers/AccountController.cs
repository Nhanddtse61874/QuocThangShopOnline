using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static LogicHandler.Handler.AccountHandler.Login.Login;

namespace QuocThangShopOnline.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AccountController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Login(LoginViewModels request)
        {
             var result = _mediator.Send(request).Result;
            if(result.Successed)
                return RedirectToAction("Index", "Category");
            return View(result.Errors);
        }

        [HttpPost]
        public IActionResult Logout(LogoutViewModels request)
        {
            var result = _mediator.Send(request).Result;
            return RedirectToAction("Index", "Category");
        }
    }
}
