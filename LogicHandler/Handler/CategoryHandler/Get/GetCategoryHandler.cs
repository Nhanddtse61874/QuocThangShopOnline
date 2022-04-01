using AutoMapper;
using LogicHandler.DTO;
using MediatorHandler.RepositoryInterface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogicHandler.Handler.CategoryHandler
{
    #region Get All Category
    public class GetAllCategoryRequest : IRequest<List<CategoryDTO>>
    {
        [FromRoute]
        public int? PageIndex { get; set; }

        [FromRoute]
        public int? PageSize { get; set; }
    }

    public class GetAllCategoryHandler : HandlerBase, IRequestHandler<GetAllCategoryRequest, List<CategoryDTO>>
    {
        private readonly ICategoryRepository _repository;
        public GetAllCategoryHandler(ICategoryRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<List<CategoryDTO>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
            => _mapper.Map<List<CategoryDTO>>(_repository.GetAll(pageIndex : request.PageIndex, pageSize : request.PageSize));
    }
    #endregion

    #region Get Category By Id
    public class GetCategoryByIdRequest : IRequest<CategoryDTO>
    {
        public int Id { get; set; }

    }

    public class GetCategoryByIdHandler : HandlerBase, IRequestHandler<GetCategoryByIdRequest,CategoryDTO>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdHandler(ICategoryRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
            => _mapper.Map<CategoryDTO>(await _repository.GetByIdAsync(request.Id));
        
    }
    #endregion
}
