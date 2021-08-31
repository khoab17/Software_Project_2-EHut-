using AutoMapper;
using BEL.Model;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.AutoMapperConfig
{
    public class MapperSetting:Profile
    {
        public MapperSetting()
        {
            CreateMap<Admin, AdminModel>();
            CreateMap<BankInformation, BankInformationModel>();
            CreateMap<Brand, BrandModel>();
            CreateMap<Credential, CredentialModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<Deliveryman, DeliverymanModel>();
            CreateMap<Discount, DiscountModel>();
            CreateMap<Image, ImageModel>();
            CreateMap<Manager, ManagerModel>();
            CreateMap<Order, OrderModel>();
            CreateMap<ProductDistribution, ProductDistributionModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<SalesRecord, SalesRecordModel>();
            CreateMap<Shop, ShopModel>();
            CreateMap<ShopReview, ShopReviewModel>();

        }
    }
}
