using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SalesProject.Application.Interface;
using SalesProject.Application.Main;
using SalesProject.Domain.Core;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Infraestructure.Repository;
using SalesProject.Transversal.Mapper;
using System.Text;

namespace SalesProject.Services.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApiDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("API_DB"));
            });

            #region set up authentication 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization();
            #endregion

           
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddTransient<IGenericRepositoryTwo<Customer>, CustomerRepository>();
            services.AddTransient<ICustomerDomain, CustomerDomain>();
            services.AddTransient<ICustomerApplication, CustomerApplication>();

            services.AddTransient<IGenericRepositoryTwo<UserSy>, AuthenticateRepository>();
            services.AddTransient<IAuthenticateDomain, AuthenticateDomain>();
            services.AddTransient<IAuthenticateApplication, AuthenticationApplication>();

            services.AddTransient<IGenericRepositoryThree<CustomerCategory>, CustomerCatRepository>();
            services.AddTransient<ICustomerCatDomain, CustomerCatDomain>();
            services.AddTransient<ICustomerCatApplication, CustomerCatApplication>();

            services.AddTransient<IGenericRepositoryTwo<Supplier>, SupplierRepository>();
            services.AddTransient<ISupplierDomain, SupplierDomain>();
            services.AddTransient<ISupplierApplication, SupplierApplication>();

            services.AddTransient<IGenericRepositoryThree<SupplierCategory>, SupplierCatRepository>();
            services.AddTransient<ISupplierCatDomain, SupplierCatDomain>();
            services.AddTransient<ISupplierCatApplication, SupplierCatApplication>();

            services.AddTransient<IGenericRepositoryTwo<Cellar>, CellarRepository>();
            services.AddTransient<ICellarDomain, CellarDomain>();
            services.AddTransient<ICellarApplication, CellarApplication>();

            services.AddTransient<IGenericRepositoryTwo<Product>, ProductRepository>();
            services.AddTransient<IProductDomain, ProductDomain>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<IGenericRepositoryThree<ProductBrand>, ProductBrandRepository>();
            services.AddTransient<IProductBrandDomain, ProductBrandDomain>();
            services.AddTransient<IProductBrandApplication, ProductBrandApplication>();

            services.AddTransient<IGenericRepositoryThree<ProductCategory>, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryDomain, ProductCategoryDomain>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            services.AddTransient<IGenericRepositoryThree<ProductMeasure>, ProductMeasureRepository>();
            services.AddTransient<IProductMeasureDomain, ProductMeasureDomain>();
            services.AddTransient<IProductMeasureApplication, ProductMeasureApplication>();

            services.AddTransient<IGenericRepositoryThree<MinMaxProduct>, MinMaxProductUnitsRepository>();
            services.AddTransient<IMinMaxProductUnitsDomain, MinMaxProductUnitsDomain>();
            services.AddTransient<IMinMaxProductUnitsApplication, MinMaxProductUnitsApplication>();

            services.AddTransient<IGenericRepositoryThree<DocumentType>, DocumentTypeRepository>();
            services.AddTransient<IDocumentTypeDomain, DocumentTypeDomain>();
            services.AddTransient<IDocumentTypeApplication, DocumentTypeApplication>();

            services.AddTransient<IGenericRepositoryThree<Document>, DocumentRepository>();
            services.AddTransient<IDocumentDomain, DocumentDomain>();
            services.AddTransient<IDocumentApplication, DocumentApplication>();

            /*services.AddTransient<IGenericRepository<CategorySalePrice>, SalePriceCategoryRepository>();
            services.AddTransient<ISalePriceCategoryDomain, SalePriceCategoryDomain>();
            services.AddTransient<ISalePriceCategoryApplication, SalePriceCatApplication>();*/

            services.AddTransient<IGenericRepository<BuyOrder>, BuyOrderRepository>();
            services.AddTransient<IBuyOrderDomain, BuyOrderDomain>();
            services.AddTransient<IBuyOrderApplication, BuyOrderApplication>();

            services.AddTransient<IGenericRepository<Buy>, BuyRepisotory>();
            services.AddTransient<IBuyDomain, BuyDomain>();
            services.AddTransient<IBuyApplication, BuyApplication>();

            services.AddTransient<IGenericRepository<SaleOrder>, SaleOrderRepository>();
            services.AddTransient<ISaleOrderDomain, SaleOrderDomain>();
            services.AddTransient<ISaleOrderApplication, SaleOrderApplication>();

            services.AddTransient<IGenericRepository<Sale>, SaleRepository>();
            services.AddTransient<ISaleDomain, SaleDomain>();
            services.AddTransient<ISaleApplication, SaleApplication>();

            services.AddTransient<IGenericRepository<BuyReturn>, BuyReturnRepository>();
            services.AddTransient<IBuyReturnDomain, BuyReturnDomain>();
            services.AddTransient<IBuyReturnApplication, BuyReturnApplication>();

            services.AddTransient<IGenericRepository<SaleReturn>, SaleReturnRepository>();
            services.AddTransient<ISaleReturnDomain, SaleReturnDomain>();
            services.AddTransient<ISaleReturnApplication, SaleReturnApplication>();

            services.AddTransient<IGenericRepositoryThree<CellarTransfer>, CellarTransferRepository>();
            services.AddTransient<ICellarTransferDomain, CellarTransferDomain>();
            services.AddTransient<ICellarTransferApplication, CellarTransferApplication>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
