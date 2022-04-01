using AutoMapper;
using LogicHandler.DTO;
using Persistence.EnitityModel;
using QuocThangShopOnline.Admin.Models;

namespace QuocThangShopOnline.AutoMapper
{
    public class AutoMapper : Profile
    {
        protected IMapper _mapper;

        public AutoMapper()
        {

            #region Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDTO>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDTO>().ReverseMap();
            #endregion
        }
    }
}
