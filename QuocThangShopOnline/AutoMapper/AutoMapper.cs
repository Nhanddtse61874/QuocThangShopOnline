using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.EnitityModel;
using Persistence.EnitityModel;
using QuocThangShopOnline.Areas.Admin.Models;
using QuocThangShopOnline.Models;

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
            CreateMap<ClientCategoryViewModel, CategoryDTO>().ReverseMap();

            #endregion

            #region Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();

            #endregion

            #region Customer
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerDTO>().ReverseMap();
            #endregion

            #region Order
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
            #endregion

            #region ProductDetail
            CreateMap<ProductDetail, ProductDetailDTO>().ReverseMap();
            CreateMap<ProductDetailViewModel, ProductDetailDTO>().ReverseMap();
            #endregion

            #region ImageStorage
            CreateMap<ImageStorage, ImageStorageDTO>().ReverseMap();
            CreateMap<ImageStorageViewModel, ImageStorageDTO>().ReverseMap();
            #endregion

            #region OrderDetail
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetailViewModel, OrderDetailDTO>().ReverseMap();
            #endregion

            #region Vendor
            CreateMap<Vendor, VendorDTO>().ReverseMap();
            CreateMap<ImageStorageViewModel, ImageStorageDTO>().ReverseMap();
            #endregion
        }
    }
}
