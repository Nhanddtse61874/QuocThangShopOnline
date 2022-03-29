using AutoMapper;
using LogicHandler.DAO;
using LogicHandler.DTO;
using Persistence.EnitityModel;

namespace QuocThangShopOnline.AutoMapper
{
    public class AutoMapper : Profile
    {
        protected IMapper _mapper;

        public AutoMapper()
        {

            #region Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            #endregion
        }
    }
}
