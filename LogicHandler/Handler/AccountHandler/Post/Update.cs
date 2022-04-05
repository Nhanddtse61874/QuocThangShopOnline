using AutoMapper;
using LogicHandler.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicHandler.Handler.AccountHandler.Post
{
    [Authorize]
    public static class Update
    {
        #region Commands

        #region Update Password
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

        public class Commands : ResponseViewModel, IRequest<ResponseViewModel>
        {
            [FromForm]
            public string UserName { get; set; }

            [FromForm]
            [Required(ErrorMessage = "CurrentPassword can not be empty!")]
            public string CurrentPassword { get; set; }

            [FromForm]
            [Required(ErrorMessage = "New Password can not be empty!")]
            public string NewPassword { get; set; }
        }
        public class CommandHandler : HandlerBase, IRequestHandler<Commands, ResponseViewModel>
        {
            private readonly IApplicationUserService _applicationUserService;

            public CommandHandler(IMapper mapper,
                IApplicationUserService applicationUserService) : base(mapper)
            {
                _applicationUserService = applicationUserService;
            }

            public async Task<ResponseViewModel> Handle(Commands request, CancellationToken cancellationToken)
            {
                var result = await _applicationUserService.UpdateAsync(request.UserName, request.CurrentPassword, request.NewPassword);

                return new ResponseViewModel { Result = result };
            }
        }
        #endregion

        #region Change Information
        public class Query : IRequest<AdminViewModel>
        {
        }

        public class QueryHandler : HandlerBase, IRequestHandler<Query, AdminViewModel>
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IApplicationUserService _applicationUserService;
            public QueryHandler(IMapper mapper,
                IHttpContextAccessor httpContextAccessor,
                IApplicationUserService applicationUserService) : base(mapper)
            {
                _httpContextAccessor = httpContextAccessor;
                _applicationUserService = applicationUserService;
            }

            public async Task<AdminViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var currentUser = await _applicationUserService.GetUserByName(userName);
                return new AdminViewModel
                {
                    Email = currentUser.Email,
                    Phone = currentUser.Phone,
                    UrlImage = currentUser.UrlImage
                };
            }
        }

        public class ChangeInformationCommand : IRequest
        {
            [FromForm]
            public string Email { get; set; }

            [FromForm]
            public string Phone { get; set; }

            [FromForm]
            public string UrlImage { get; set; }
        }

        public class ChangeInformationHandler : HandlerBase, IRequestHandler<ChangeInformationCommand>
        {
            private readonly IApplicationUserService _applicationUserService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public ChangeInformationHandler(IMapper mapper,
                IApplicationUserService applicationUserService,
                IHttpContextAccessor httpContextAccessor) : base(mapper)
            {
                _httpContextAccessor = httpContextAccessor;
                _applicationUserService = applicationUserService;
            }

            public async Task<Unit> Handle(ChangeInformationCommand request, CancellationToken cancellationToken)
            {
                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    await _applicationUserService.ChangeInformationAsync(userName, request.Email, request.Phone, request.UrlImage);
                }
                return Unit.Value;
            }
            #endregion
        }
        #region Models
        public class ResponseViewModel
        {
            public bool Result { get; set; }
        }

        public class AdminViewModel
        {
            public string Email { get; set; }

            public string Phone { get; set; }

            [Display(Name = "Avatar")]
            public string UrlImage { get; set; }

            public string FileName => Path.GetFileName(UrlImage);
        }
        #endregion

        #endregion
    }
}
