using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
