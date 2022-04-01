using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.RepositoryInterface;
using MediatR;
using Persistence.EnitityModel;

namespace LogicHandler.Handler.ProductHandler.Post
{
    #region Create Product
    public class CreateProductRequest : IRequest
    {
        public ProductDTO Product { get; set; }
    }

    public class CreateProductHandler : HandlerBase, IRequestHandler<CreateProductRequest, Unit>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Product>(request.Product));
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Update Product
    public class UpdateProductRequest : IRequest
    {
        public ProductDTO Product { get; set; }
    }

    public class UpdateProductHandler : HandlerBase, IRequestHandler<UpdateProductRequest, Unit>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Product>(request.Product));
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Delete Product
    public class DeleteProductRequest : IRequest
    {
        public int  Id { get; set; }
    }

    public class DeleteProductHandler : HandlerBase, IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Delete Range Product
    public class DeleteProductRangeRequest : IRequest
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteProductRangeHandler : HandlerBase, IRequestHandler<DeleteProductRangeRequest, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductRangeHandler(IMapper mapper, IProductRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductRangeRequest request, CancellationToken cancellationToken)
        {
             _repository.DeleteRange(_repository.Get(x => request.Ids.Contains(x.Id)).ToList());
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion
}
