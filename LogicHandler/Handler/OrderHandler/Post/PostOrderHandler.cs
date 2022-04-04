using AutoMapper;
using DataAccessLayer.RepositoryInterface;
using LogicHandler.DTO;
using MediatR;
using Persistence.EnitityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicHandler.Handler.OrderHandler
{
    #region Create Order
    public class CreateCustomerRequest : IRequest
    {
        public OrderDTO Order { get; set; }
    }

    public class CreateCustomerHandler : HandlerBase, IRequestHandler<CreateCustomerRequest, Unit>
    {
        private readonly IOrderRepository _repository;

        public CreateCustomerHandler(IOrderRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Order>(request.Order));
            return await Task.FromResult(Unit.Value);
        }

    }
    #endregion

    #region Update Customer
    public class UpdateOrderRequest : IRequest
    {
        public OrderDTO Order { get; set; }
    }

    public class UpdateCustomerHandler : HandlerBase, IRequestHandler<UpdateOrderRequest, Unit>
    {
        private readonly IOrderRepository _repository;

        public UpdateCustomerHandler(IOrderRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Order>(request.Order));
            return await Task.FromResult(Unit.Value);
        }

    }
    #endregion

    #region Delete Customer
    public class DeleteCustomerRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteOrderHandler : HandlerBase, IRequestHandler<DeleteCustomerRequest, Unit>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderHandler(IOrderRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion
}
