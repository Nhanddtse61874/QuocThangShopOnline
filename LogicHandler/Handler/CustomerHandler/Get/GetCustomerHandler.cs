using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.RepositoryInterface;
using MediatR;

namespace LogicHandler.Handler.CustomerHandler.Get
{
    #region Get All Customers
    public class GetAllCustomer : IRequest<IList<CustomerDTO>>
    {

    }

    public class GetAllCustomerHandler : HandlerBase, IRequestHandler<GetAllCustomer, IList<CustomerDTO>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomerHandler(ICustomerRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<IList<CustomerDTO>> Handle(GetAllCustomer request, CancellationToken cancellationToken) => _mapper.Map<List<CustomerDTO>>(_repository.GetAll());

    }
    #endregion

    #region Get Customer By Id
    public class GetCustomerById : IRequest<CustomerDTO>
    {
        public int Id { get; set; }
    }

    public class GetCustomerByIdHandler : HandlerBase, IRequestHandler<GetCustomerById, CustomerDTO>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdHandler(ICustomerRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerById request, CancellationToken cancellationToken) => _mapper.Map<CustomerDTO>(await _repository.GetByIdAsync(request.Id));
       
    }
    #endregion
}
