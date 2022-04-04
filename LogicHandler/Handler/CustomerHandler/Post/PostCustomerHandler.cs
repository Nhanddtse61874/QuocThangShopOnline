using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.RepositoryInterface;
using MediatR;
using Persistence.EnitityModel;

namespace LogicHandler.Handler.CustomerHandler
{
    #region Create Customer
    public class CreateCustomerRequest : IRequest
    {
        public CustomerDTO Customer { get; set; }
    }

    public class CreateCustomerHandler : HandlerBase, IRequestHandler<CreateCustomerRequest, Unit>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository repository, IMapper mapper ) : base( mapper )
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Customer>(request.Customer));
            return await Task.FromResult(Unit.Value);
        }
      
    }
    #endregion

    #region Update Customer
    public class UpdateCustomerRequest : IRequest
    {
        public CustomerDTO Customer { get; set; }
    }

    public class UpdateCustomerHandler : HandlerBase, IRequestHandler<UpdateCustomerRequest, Unit>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerHandler(ICustomerRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Customer>(request.Customer));
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Delete Customer
    public class DeleteCustomerRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerHandler : HandlerBase, IRequestHandler<DeleteCustomerRequest, Unit>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerHandler(ICustomerRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async  Task<Unit> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
           await  _repository.DeleteAsync(request.Id);
           return await Task.FromResult(Unit.Value);
        }
    }
    #endregion
}
