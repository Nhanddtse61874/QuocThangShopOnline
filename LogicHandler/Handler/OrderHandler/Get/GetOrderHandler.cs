using AutoMapper;
using DataAccessLayer.RepositoryInterface;
using MediatR;
using Persistence.EnitityModel;

namespace LogicHandler.Handler.OrderHandler.Get
{
    #region Get All Order By User Id
    public class GetAllOrderByUserIdRequest : IRequest<IList<Order>>
    {
        public int UserId { get; set; }
    }

    public class GetAllOrderByUserIdHandler : HandlerBase, IRequestHandler<GetAllOrderByUserIdRequest, IList<Order>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrderByUserIdHandler(IMapper mapper, IOrderRepository repository) : base(mapper)   
        {
            _repository = repository;
        }

        public async Task<IList<Order>> Handle(GetAllOrderByUserIdRequest request, CancellationToken cancellationToken) 
        => _mapper.Map<IList<Order>>(_repository.GetAll(x => x.CustomerId == request.UserId));
    }
    #endregion

    #region Get All Order 
    public class GetAllOrderRequest : IRequest<IList<Order>>
    {
       
    }

    public class GetAllOrderHandler : HandlerBase, IRequestHandler<GetAllOrderRequest, IList<Order>>
    {
        private readonly IOrderRepository _repository;

        public GetAllOrderHandler(IMapper mapper, IOrderRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<IList<Order>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        => _mapper.Map<IList<Order>>(_repository.GetAll());
    }
    #endregion

    #region Get Order By Id
    public class GetOrderByIdRequest : IRequest<Order>
    {
        public int Id { get; set; }
    }

    public class GetOrderByIdHandler : HandlerBase, IRequestHandler<GetOrderByIdRequest, Order>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdHandler(IMapper mapper, IOrderRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        => _mapper.Map<Order>(await _repository.GetByIdAsync(request.Id));

    }
    #endregion

}
