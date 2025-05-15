using AutoMapper;
using SalesProject.Application.DTO.authentication;
using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.buy.buy_detail;
using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.buy_order.buy_order_detail;
using SalesProject.Application.DTO.buy_return.buy_return;
using SalesProject.Application.DTO.buy_return.buy_return_detail;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer_det;
using SalesProject.Application.DTO.customer.category;
using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.batch;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.DTO.product.min_max;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.DTO.product.status;
using SalesProject.Application.DTO.sale.sale;
using SalesProject.Application.DTO.sale.sale_detail;
using SalesProject.Application.DTO.sale_order.sale_order;
using SalesProject.Application.DTO.sale_order.sale_order_detail;
using SalesProject.Application.DTO.sale_price_category;
using SalesProject.Application.DTO.sale_return.sale_return;
using SalesProject.Application.DTO.sale_return.sale_return_det;
using SalesProject.Application.DTO.supplier.category;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Application.DTO.transaction_state;
using SalesProject.Application.DTO.user.user;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Entity.Models.pagination;

namespace SalesProject.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserSy, AuthenticateDTO>();
            CreateMap<AuthenticateDTO, UserSy>();
            CreateMap<AuthenticateCreateDTO, UserSy>();
            CreateMap<AuthenticateUpdateDTO, UserSy>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<PaginationParametersDTO, PaginationParameters>();

            CreateMap<CustomerCategory, CustomerCatDTO>();
            CreateMap<CustomerCatCreateDTO, CustomerCategory>();
            CreateMap<CustomerCatUpdateDTO, CustomerCategory>();

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierCreateDTO, Supplier>();
            CreateMap<SupplierUpdateDTO, Supplier>();

            CreateMap<SupplierCategory, SupplierCatDTO>();
            CreateMap<SupplierCatCreateDTO, SupplierCategory>();
            CreateMap<SupplierCatUpdateDTO, SupplierCategory>();

            CreateMap<Cellar, CellarDTO>();
            CreateMap<CellarCreateDTO, Cellar>();
            CreateMap<CellarUpdateDTO, Cellar>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();

            CreateMap<ProductCategory, ProductCatDTO>();
            CreateMap<ProductCatCreateDTO, ProductCategory>();
            CreateMap<ProductCatUpdateDTO, ProductCategory>();

            CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductBrandCreateDTO, ProductBrand>();
            CreateMap<ProductBrandUpdateDTO, ProductBrand>();

            CreateMap<ProductMeasure, ProductMeasureDTO>();
            CreateMap<ProductMeasureCreateDTO, ProductMeasure>();
            CreateMap<ProductMeasureUpdateDTO, ProductMeasure>();

            CreateMap<ProductState, ProductStateDTO>();

            CreateMap<MinMaxProduct, MinMaxProductUnitsDTO>();
            CreateMap<MinMaxProductUnitsCreateDTO, MinMaxProduct>();
            CreateMap<MinMaxProductUnitsUpdateDTO, MinMaxProduct>();

            CreateMap<BatchProduct, BatchProductDTO>();
            CreateMap<BatchProductCreateDTO, BatchProduct>();
            CreateMap<BatchProductUpdateDTO, BatchProduct>();

            CreateMap<DocumentType, DocumentTypeDTO>();
            CreateMap<DocumentTypeCreateDTO, DocumentType>();
            CreateMap<DocumentTypeUpdateDTO, DocumentType>();

            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentCreateDTO, Document>();
            CreateMap<DocumentUpdateDTO, Document>();

            CreateMap<CategorySalePrice, SalePriceCatDTO>();
            CreateMap<SalePriceCatCreateDTO, CategorySalePrice>();
            CreateMap<SalePriceCatUpdateDTO, CategorySalePrice>();

            CreateMap<BuyOrder, BuyOrderDTO>().ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.SupplierCodeNavigation))
                                              .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation));

            CreateMap<BuyOrderCreateDTO, BuyOrder>();
            CreateMap<BuyOrderUpdateDTO, BuyOrder>();
            CreateMap<BuyOrderDet, BuyOrderDetDTO>();
            CreateMap<BuyOrderDetCreateDTO, BuyOrderDet>();
            CreateMap<BuyOrderDetUpdateDTO, BuyOrderDet>();

            CreateMap<Buy, BuyDTO>().ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.SupplierCodeNavigation))
                                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation));

            CreateMap<BuyCreateDTO, Buy>();
            CreateMap<BuyUpdateDTO, Buy>();

            CreateMap<BuyDet, BuyDetDTO>();
            CreateMap<BuyDetCreateDTO, BuyDet>();
            CreateMap<BuyDetUpdateDTO, BuyDet>();

            CreateMap<BuyOrder, Buy>();
            CreateMap<BuyOrderDet, BuyDet>();

            CreateMap<SaleOrder, SaleOrderDTO>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation))
                                                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.CustomerCodeNavigation));

            CreateMap<SaleOrderCreateDTO, SaleOrder>();
            CreateMap<SaleOrderUpdateDTO, SaleOrder>();

            CreateMap<SaleOrderDet, SaleOrderDetDTO>();
            CreateMap<SaleOrderDetCreateDTO, SaleOrderDet>();
            CreateMap<SaleOrderDetUpdateDTO, SaleOrderDet>();

            CreateMap<Sale, SaleDTO>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation))
                                      .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.CustomerCodeNavigation));

            CreateMap<SaleCreateDTO, Sale>();
            CreateMap<SaleUpdateDTO, Sale>();

            CreateMap<SaleDet, SaleDetDTO>();
            CreateMap<SaleDetCreateDTO, SaleDet>();
            CreateMap<SaleDetUpdateDTO, SaleDet>();

            CreateMap<SaleOrder, Sale>();
            CreateMap<SaleOrderDet, SaleDet>();

            CreateMap<BuyReturn, BuyReturnDTO>().ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.SupplierCodeNavigation))
                                                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation));
            CreateMap<BuyReturnCreateDTO, BuyReturn>();
            CreateMap<BuyReturnUpdateDTO, BuyReturn>();

            CreateMap<BuyReturnDet, BuyReturnDetDTO>();
            CreateMap<BuyReturnDetCreateDTO, BuyReturnDet>();
            CreateMap<BuyReturnDetUpdateDTO, BuyReturnDet>();

            CreateMap<SaleReturn, SaleReturnDTO>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.CustomerCodeNavigation))
                                                  .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserCodeNavigation));

            CreateMap<SaleReturnCreateDTO, SaleReturn>();
            CreateMap<SaleReturnUpdateDTO, SaleReturn>();

            CreateMap<SaleReturnDet, SaleReturnDetDTO>();
            CreateMap<SaleReturnDetCreateDTO, SaleReturnDet>();
            CreateMap<SaleReturnDetUpdateDTO, SaleReturnDet>();

            CreateMap<CellarTransfer, CellarTransferDTO>();
            CreateMap<CellarTransferCreateDTO, CellarTransfer>();
            CreateMap<CellarTransferUpdateDTO, CellarTransfer>();

            CreateMap<CellarTransferDet, CellarTransferDetDTO>();
            CreateMap<CellarTransferDetCreateDTO, CellarTransferDet>();
            CreateMap<CellarTransferDetUpdateDTO, CellarTransferDet>();

            CreateMap<UserSy, UserDTO>();

            CreateMap<TransactionState, TransactionStateDTO>();

        }
    }
}