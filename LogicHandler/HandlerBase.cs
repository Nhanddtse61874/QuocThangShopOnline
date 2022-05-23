using AutoMapper;

namespace LogicHandler
{
    public class HandlerBase
    {
        protected readonly IMapper _mapper;
        public HandlerBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
