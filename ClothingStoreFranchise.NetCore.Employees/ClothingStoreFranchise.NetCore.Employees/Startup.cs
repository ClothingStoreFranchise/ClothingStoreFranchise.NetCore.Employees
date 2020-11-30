using Autofac;
using Autofac.Extensions.DependencyInjection;
using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Mapper;
using ClothingStoreFranchise.NetCore.Common.RabbitMq;
using ClothingStoreFranchise.NetCore.Common.RabbitMq.Impl;
using ClothingStoreFranchise.NetCore.Common.Security;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.EventHandlers;
using ClothingStoreFranchise.NetCore.Employees.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using System;

namespace ClothingStoreFranchise.NetCore.Employees
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        protected IMapperProvider MapperProvider { get; } = new EmployeesMapperProvider();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var options = Configuration.GetOptions<RabbitMqOptions>("rabbitMq");

            services.AddEventBus(options);
            services.AddIntegrationServices(options);
            services.AddDiscoveryClient(Configuration);
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAuthentication("Basic")
                 .AddScheme<BasicAuthenticationOptions, CustomAuthenticationHandler>("Basic", null);

            services.AddEmployeesServices();

            services.AddCustomDbContext(Configuration);

            services.AddSingleton(MapperProvider);

            services.AddSwaggerGen(x =>
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }));

            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDiscoveryClient();

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            //inventory microservice events
            eventBus.Subscribe<CreateWarehouseEvent, WarehouseCreatedHandler>();
            eventBus.Subscribe<UpdateWarehouseEvent, WarehouseUpdatedHandler>();
            eventBus.Subscribe<CreateShopEvent, ShopCreatedHandler>();
            eventBus.Subscribe<UpdateShopEvent, ShopUpdatedHandler>();
        }

    }
}
