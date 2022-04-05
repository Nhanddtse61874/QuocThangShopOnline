using AutoMapper;
using LogicHandler.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LogicHandler.Handler.AccountHandler.Login
{
    public static class Login
    {
        #region Queries
        public class Get : IRequest<string>
        {
            [FromRoute]
            public string ReturnUrl { get; set; }
        }

        public class GetHandler : HandlerBase, IRequestHandler<Get, string>
        {
            public GetHandler(IMapper mapper) : base(mapper)
            {
            }

            public Task<string> Handle(Get request, CancellationToken cancellationToken)
                => Task.FromResult(request.ReturnUrl);
        }

        public class LoginViewModels : ResponseModel, IRequest<ResponseModel>
        {
            [FromForm]
            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Tên Đăng Nhập")]
            public string Username { get; set; }

            [FromForm]
            [Required(ErrorMessage = "{0} không được để trống")]
            [Display(Name = "Mật Khẩu")]
            public string Password { get; set; }
        }

        public class LoginHandler : HandlerBase, IRequestHandler<LoginViewModels, ResponseModel>
        {
            private readonly IApplicationUserService _applicationUserService;

            public LoginHandler(IMapper mapper,
                IApplicationUserService applicationUserService) : base(mapper)
            {
                _applicationUserService = applicationUserService;
            }

            public async Task<ResponseModel> Handle(LoginViewModels request, CancellationToken cancellationToken)
            {
                var result = await _applicationUserService.SignInAsync(request.Username, request.Password);

                IDictionary<string, string[]> errors = new Dictionary<string, string[]>();
                if (!result)
                {
                    string errorMessage;
                    errorMessage = "Incorrect username or password.";
                    errors.Add("Login Failed", new string[] { errorMessage });
                }

                return new ResponseModel
                {
                    Successed = result,
                    Errors = errors
                };
            }
        }

        public class LogoutViewModels : IRequest
        {
        }

        public class LogoutHandler : HandlerBase, IRequestHandler<LogoutViewModels>
        {
            private readonly IApplicationUserService _applicationUserService;

            public LogoutHandler(IMapper mapper,
                IApplicationUserService applicationUserService) : base(mapper)
            {
                _applicationUserService = applicationUserService;
            }

            public async Task<Unit> Handle(LogoutViewModels request, CancellationToken cancellationToken)
            {
                await _applicationUserService.SignOutAsync();

                return Unit.Value;
            }
        }
        #endregion
    }

    public class ResponseModel
    {
        public ResponseModel()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public bool Successed { get; set; }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}
