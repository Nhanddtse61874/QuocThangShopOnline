using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.RepositoryInterface;
using MediatR;

namespace LogicHandler.Handler.ProductHandler.Get
{
    #region Get All Product

    public class GetAllProductRequest : IRequest<IList<ProductDTO>>
    {
        public int? PageSize { get; set; }

        public int? PageIndex { get; set; }

    }

    public class GetAllProductHandler : HandlerBase, IRequestHandler<GetAllProductRequest, IList<ProductDTO>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductHandler(IMapper mapper , IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }
        public async Task<IList<ProductDTO>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        
        =>  _mapper.Map<IList<ProductDTO>>(_repository.GetAll(pageIndex: request.PageIndex, pageSize: request.PageSize));
    }
    #endregion

    #region Get Product By Id
    public class GetProductByIdRequest : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : HandlerBase, IRequestHandler<GetProductByIdRequest, ProductDTO>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<ProductDTO> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        =>  _mapper.Map<ProductDTO>(await _repository.GetByIdAsync(request.Id));
    }
    #endregion

    #region Get Product By Category Id
    public class GetProductByCategoryIdRequest : IRequest<IList<ProductDTO>>
    {
        public int CategoryId { get; set; }
    }

    public class GetProductByCategoryIdHandler : HandlerBase, IRequestHandler<GetProductByCategoryIdRequest, IList<ProductDTO>>
    {
        private readonly IProductRepository _repository;

        public GetProductByCategoryIdHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<IList<ProductDTO>> Handle(GetProductByCategoryIdRequest request, CancellationToken cancellationToken)
        => _mapper.Map<IList<ProductDTO>>( _repository.Get(x => x.CategoryId == request.CategoryId));
    }
    #endregion
}

